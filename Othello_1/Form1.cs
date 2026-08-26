using Othello_1.TicTacToe;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace Othello_1
{
    internal enum Tiles
    {
        Empty,
        O_Black,
        O_White
    }

    public partial class Form1 : Form
    {

        PictureBox[,] board;
        OthelloPosition position;
        bool isBlackTurn = true;
        bool play = true;
        const int SIZE = 8;

        public Form1()
        {
            InitializeComponent();
            position = new OthelloPosition();
            board = new PictureBox[SIZE, SIZE];
            PaintBoard();
        }

        void PaintBoard()
        {

            gbBoard.Width = (SIZE * pbModel.Width) + 50;
            gbBoard.Height = (SIZE * pbModel.Height) + 50;
            for (int row = 0; row < SIZE; ++row)
            {
                for (int col = 0; col < SIZE; ++col)
                {
                    PictureBox pb = new PictureBox();
                    pb.BackColor = pbModel.BackColor;
                    pb.Size = pbModel.Size;
                    pb.Image = pbModel.Image;
                    pb.SizeMode = pbModel.SizeMode;

                    pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.Location = new Point((col * pbModel.Width) + 10, (row * pbModel.Height) + 10);

                    int[] arr = { row, col };
                    pb.Tag = arr;
                    pb.Click += (s, e) => { BoxClicked(s, e); };
                    board[row, col] = pb;
                    gbBoard.Controls.Add(pb);
                }
            }
            RedrawBoard();
        }
        void BoxClicked(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            var location = pb.Tag;

            if (location is int[] arr && arr.Length >= 2)
            {
                int row = arr[0];
                int col = arr[1];

                if (play)
                {
                    if (!isBlackTurn || position.IsTerminal())
                    {
                        return;
                    }

                    if (isBlackTurn)
                    {
                        if (!position.isValidMove(row, col, isBlackTurn))
                        {
                            MessageBox.Show("Invalid move. Please try again.");
                            return;
                        }

                        OthelloPosition newPosition = new OthelloPosition();
                        for (int r = 0; r < SIZE; r++)
                        {
                            for (int c = 0; c < SIZE; c++)
                            {
                                newPosition.tile[r, c] = position.tile[r, c];
                            }
                        }

                        List<(int r, int c)> flippables = newPosition.getFlippables(row, col, isBlackTurn);
                        newPosition.tile[row, col] = Tiles.O_Black;
                        for (int i = 0; i < flippables.Count; i++)
                        {
                            int flipRow = flippables[i].r;
                            int flipCol = flippables[i].c;
                            newPosition.tile[flipRow, flipCol] = Tiles.O_Black;
                        }

                        position = newPosition;
                        RedrawBoard();
                        this.Update();

                        if (position.IsTerminal())
                        {
                            ifGameOver();
                            return;
                        }
                    }

                    isBlackTurn = false;
                    aisturn();
                }
            }
        }

        void aisturn()
        {
            if (position.IsTerminal())
            {
                ifGameOver();
                return;
            }

            bool hasValidMove = false;

            for (int r = 0; r < SIZE; ++r)
            {
                for (int c = 0; c < SIZE; ++c)
                {
                    if (position.isValidMove(r, c, false))
                    {
                        hasValidMove = true;
                        break;
                    }
                }
                if (hasValidMove)
                {
                    break;
                }
            }
            if (!hasValidMove)
            {
                MessageBox.Show("No valid moves, White is passing its turn");
                isBlackTurn = true;

                if (position.IsTerminal())
                {
                    ifGameOver();//quick 3 lines to check if now that ai has passed its turn to black, to see if black is also terminal, if so the n gameover
                }

                return;
            }

            int depth = (int)numericUpDown1.Value;
            var (bestVal, bestPos) = MinimaxSolver.Minimax(position, depth, false);
            position = (OthelloPosition)bestPos;
            RedrawBoard();

            if (position.IsTerminal())
            {
                ifGameOver();
                return;
            }

            bool playerHasValidMove = false;//do what we did for hasValidMove but for player, we do it here because its harder to do in players turn since it only triggers when you click, so this does it automatically, and since the first move is always made by player, and anyways there should always be valid moves in the first round of the game, we dont need it to be checked on the first round, and after all human plays the ai will run this
            for (int r = 0; r < SIZE; ++r)
            {
                for (int c = 0; c < SIZE; ++c)
                {
                    if (position.isValidMove(r, c, true))
                    {
                        playerHasValidMove = true;
                        break;
                    }
                }
                if (playerHasValidMove)
                {
                    break;
                }
            }
            if (!playerHasValidMove)
            {
                MessageBox.Show("No valid moves, You are passing your turn");
                isBlackTurn = false;
                aisturn();
            }
            else
            {
                isBlackTurn = true;
            }
        }
        private void RedrawBoard()
        {
            for (int row = 0; row < SIZE; ++row)
            {
                for (int col = 0; col < SIZE; ++col)
                {

                    if (position.tile[row, col] == Tiles.O_Black)
                    {
                        board[row, col].Image = pbBlack.Image;
                    }
                    else if (position.tile[row, col] == Tiles.O_White)
                    {
                        board[row, col].Image = pbWhite.Image;
                    }
                    else
                    {
                        board[row, col].Image = pbModel.Image;
                    }
                }
            }
        }

        private void ifGameOver()
        {
            if (position.IsTerminal())
            {
                int winner = position.checkWin();
                if (winner == 1)
                {
                    MessageBox.Show("Black wins! Click Restart");
                }
                else if (winner == -1)
                {
                    MessageBox.Show("White wins! Click Restart");
                }
                else
                {
                    MessageBox.Show("It's a draw! Click Restart");
                }
                play = false;
            }
        }

        private void restartClick(object sender, EventArgs e)
        {
            position = new OthelloPosition();
            play = true;
            isBlackTurn = true; //incase it ended on White's turn
            RedrawBoard();
        }
        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
