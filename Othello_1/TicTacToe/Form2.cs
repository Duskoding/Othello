using Othello_1.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Othello_1;
using System.Drawing;
using System.Windows.Forms;

namespace Othello_1.TicTacToe
{
    internal enum Tiles//figured enum because "each cell as Empty, Black, or white"
    {
        Empty,
        X,
        O
    }

    public partial class Form2 : Form
    {
        PictureBox[,] board;
        TicTacToePosition position;
        const int SIZE = 3;
        bool isXTurn = true; //true is x, false is o
        bool play = true;

        public Form2()
        {
            InitializeComponent();
            position = new TicTacToePosition();
            board = new PictureBox[SIZE, SIZE];
            PaintBoard();
        }

        void PaintBoard()
        {
            gbBoard.Width = (SIZE * pbModel.Width) + 100;
            gbBoard.Height = (SIZE * pbModel.Height) + 100;
            for (int row = 0; row < SIZE; ++row)
            {
                for (int col = 0; col < SIZE; ++col)
                {
                    PictureBox pb = new PictureBox();
                    pb.BackColor = pbModel.BackColor;
                    pb.Size = pbModel.Size;
                    pb.Image = pbModel.Image;
                    pb.SizeMode = pbModel.SizeMode;//AI helped, the images kept being stretched so you can only see the top left

                    pb.Location = new Point(col * pbModel.Width, row * pbModel.Height); //had help witth ai for dynamic sizing, i want it to look nice
                    
                    int[] arr = { row, col };
                    //position = Tiles.Empty;
                    pb.Tag = arr;
                    pb.Click += (s, e) => { BoxClicked(s, e); };//got confused at first and looked it up, s and e are sender and event stuff
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

            if (play == true)
            {
                if (location is int[] arr && arr.Length >= 2)
                {
                    int row = arr[0];
                    int col = arr[1];

                    int arrIndex = (row * SIZE) + col; //arr is a 1d, looked up the formula to tuen a 2d array into a 1d array. (y * width) + x, as discovered in the screen position, row is y, col is x. size is the only thing left so thats probably our width
                                                       //game logic
                    if (position.tile[arrIndex] != Tiles.Empty || position.IsTerminal())
                    {
                        return; //for cant play, maybe i should also make a lock when game ends
                    }

                    if (isXTurn)
                    {
                        position.tile[arrIndex] = Tiles.X;
                        RedrawBoard();
                        ifGameOver();
                        isXTurn = !isXTurn;
                    }
                    //else
                    //{
                    //position.tile[arrIndex] = Tiles.O;
                    //board[row, col].Image = Resources.O;
                    //}    was trying to do this to do this so player could do each for the bonus section but its not wise to attempt before i just complete the base assignment, also this was the code before the redraw method
                    
                    if (!isXTurn && !position.IsTerminal())
                    {
                        aisTurn(); //trigger the ai to play
                        ifGameOver();
                    }
                }
            }
            else
            {

            }

        }

        void aisTurn()
        {
            int depth = (int)numericUpDown1.Value;
            var (bestVal, bestPos) = TMinimaxSolver.Minimax(position, depth, false); //the niMaxSolver purpse section was helpful on this
            position = (TicTacToePosition)bestPos;
            RedrawBoard();
            isXTurn = !isXTurn;
        }

        private void RedrawBoard()
        {
            for (int row = 0; row < SIZE; ++row)
            {
                for (int col = 0; col < SIZE; ++col)
                {
                    int arrIndex = (row * SIZE) + col;

                    if (position.tile[arrIndex] == Tiles.X)
                    {
                        board[row, col].Image = pbX.Image;
                    }
                    else if (position.tile[arrIndex] == Tiles.O)
                    {
                        board[row, col].Image = pbO.Image;
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
                double heuristicValue = position.HeuristicValue();
                if (heuristicValue == 1)
                {
                    MessageBox.Show("X wins! Click Restart");
                }
                else if (heuristicValue == -1)
                {
                    MessageBox.Show("O wins! Click Restart");
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
            position = new TicTacToePosition();
            play = true;
            isXTurn = true; //incase it ended on Os turn
            RedrawBoard();
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
