using Othello_1.TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_1
{
    internal class OthelloPosition : IGamePosition
    {
        public Tiles[,] tile { get; set; }
        const int SIZE = 8;

        public OthelloPosition()
        {
            tile = new Tiles[SIZE, SIZE];
            for (int r = 0; r < SIZE; r++) 
            {
                for (int c = 0; c < SIZE; c++)
                {
                    tile[r, c] = Tiles.Empty;
                }
            }

            int midleft = (SIZE / 2) - 1;
            int midright = SIZE / 2;

            tile[midleft, midleft] = Tiles.O_White;
            tile[midright, midright] = Tiles.O_White;
            tile[midleft, midright] = Tiles.O_Black;
            tile[midright, midleft] = Tiles.O_Black;
        }


        public double HeuristicValue()
        {
            if(IsTerminal())
            {
                int winner = checkWin();
                if (winner == 1)
                {
                    return double.MaxValue; // Black wins
                }
                else if (winner == -1)
                {
                    return double.MinValue; // White wins
                }
                else
                {
                    return 0;
                }
            } //short stop for if it sees a win in a further depth

            int blackCount = 0;
            int whiteCount = 0;
            for (int r = 0; r < SIZE; r++)
            {
                for(int c = 0; c < SIZE; c++)
                {
                    if (tile[r, c] == Tiles.O_Black)
                    {
                        blackCount++;
                    }
                    else if (tile[r, c] == Tiles.O_White)
                    {
                        whiteCount++;
                    }
                }
            }
            if((blackCount + whiteCount) == 0)
            {
                return 0; //avoid divide by zero
            }

            return (double)(blackCount - whiteCount) / (blackCount + whiteCount);
        }
        public bool IsTerminal()
        {
            for (int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    if (isValidMove(r, c, true))
                    {
                        return false;//not terminal since there is a move for black
                    }
                }

                for (int c = 0; c < SIZE; c++)
                {
                    if (isValidMove(r, c, false))
                    {
                        return false;//not terminal since there is a move for white
                    }
                }
            }
            return true; //means white or black cant move, so its terminal
        }

        public IGamePosition[] GetChildren(bool maximizingPlayer)
        {
            List<IGamePosition> children = new List<IGamePosition>();

            Tiles piece = maximizingPlayer ? Tiles.O_Black : Tiles.O_White;

            for (int r = 0; r < SIZE; r++)
            {
                for(int c = 0; c < SIZE; c++)
                {
                    if(isValidMove(r, c, maximizingPlayer)) { 
                    
                        OthelloPosition clone = new OthelloPosition();

                        for (int i = 0; i < SIZE; i++)
                        {
                            for (int j = 0; j < SIZE; j++)
                            {
                                clone.tile[i, j] = tile[i, j];
                            }
                        }
                        clone.tile[r, c] = piece;

                        List<(int row, int col)> flippables = getFlippables(r, c, maximizingPlayer);

                        for(int k = 0; k < flippables.Count; k++)
                        {
                            int row = flippables[k].row;
                            int col = flippables[k].col;
                            clone.tile[row, col] = piece;
                        }
                        children.Add(clone);
                    }
                }
            }
            return children.ToArray();
        }

        public int checkWin()
        {
            int blackPieces = 0;
            int whitePieces = 0;

            for(int r = 0; r < SIZE; r++)
            {
                for (int c = 0; c < SIZE; c++)
                {
                    if (tile[r, c] == Tiles.O_Black)
                    {
                        blackPieces++;
                    }
                    else if (tile[r, c] == Tiles.O_White)
                    {
                        whitePieces++;
                    }
                }
            }

            if (blackPieces > whitePieces)
            {
                return 1;
            }
            else if (whitePieces > blackPieces)
            {
                return -1;
            }
            return 0;
        }

        public List<(int row, int col)> getFlippables(int clickRow, int clickCol, bool maximizingPlayer)
        {
            Tiles player;
            Tiles opponent;

            if (maximizingPlayer)
            {
                player = Tiles.O_Black;
                opponent = Tiles.O_White;
            }
            else
            {
                player = Tiles.O_White;
                opponent = Tiles.O_Black;
            }
            List<(int row, int col)> canFlip = new List<(int row, int col)>();

            if (tile[clickRow, clickCol] != Tiles.Empty)
            {
                return canFlip;
            }

            int[,] dirs = { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };

            for(int i = 0; i < dirs.GetLength(0); i++)
            {
                int x = dirs[i, 0];
                int y = dirs[i, 1];

                int r = clickRow + x;
                int c = clickCol + y;

                List<(int row, int col)> tempFlippables = new List<(int row, int col)>(); //stores the potential flippables

                while (r >= 0 && r < SIZE && c >= 0 && c < SIZE && tile[r, c] == opponent)
                {
                    tempFlippables.Add((r, c));
                    r += x;
                    c += y; //shift them to the next and search
                }
                //while loop ends after it doesnt find another oponents peice

                if(r >= 0 && r < SIZE && c >= 0 && c < SIZE && tile[r, c] == player)
                {
                    canFlip.AddRange(tempFlippables);
                }
                //if it does not find the players piece it cannot flip. nothing was changed, and a new list will be made next iteration
            }
            //has to go for all directions as a there is the possibility for a piece to flip in multiple directions
            return canFlip;
        }

        public bool isValidMove(int r, int c, bool maximizingPlayer)
        {
            if( r < 0 || r >= SIZE || c< 0 || c >= SIZE)
            {
                return false; //out of bounds
            }

            if (tile[r, c] != Tiles.Empty)
            {
                return false; //cant play if its filled
            }

            List<(int row, int col)> flippables = getFlippables(r, c, maximizingPlayer);
            return flippables.Count > 0;
        }
    }
}
