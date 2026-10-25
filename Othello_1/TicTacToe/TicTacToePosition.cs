using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Othello_1;

namespace Othello_1.TicTacToe
{
    internal class TicTacToePosition : IGamePosition 
    {
        public Tiles[] tile { get; set; }
        const int SIZE = 3;

        public TicTacToePosition()
        {
            int sqaureSize = SIZE * SIZE;
            tile = new Tiles[sqaureSize];
            Array.Fill(tile, Tiles.Empty); 
        }//makes the array


        public double HeuristicValue()
        {
            if(checkWin(Tiles.X))
            {
                return 1;
            }else if (checkWin(Tiles.O))
            {
                return -1;
            }else
            {
                return 0;
            }
        }
        public bool IsTerminal()
        {
            if(checkWin(Tiles.X) || checkWin(Tiles.O))
            {
                return true;
            }//if youve won you cant play anymore

            for (int i = 0; i < tile.Length; i++)
            {
                if (tile[i] == Tiles.Empty)
                {
                    return false;
                }
            }

            return true; //if theres no empty then you cant play anymore
        }
        public IGamePosition[] GetChildren(bool maximizingPlayer)
        {
            List<IGamePosition> children = new List<IGamePosition>();
            Tiles piece = maximizingPlayer ? Tiles.X : Tiles.O; //figure out which one we are

            for(int i = 0; i < tile.Length; i++)
            {
                if (tile[i] == Tiles.Empty)
                {
                    TicTacToePosition clone = new TicTacToePosition();

                    for (int j = 0; j < tile.Length; j++)
                    {
                        clone.tile[j] = tile[j];
                    }

                    clone.tile[i] = piece;

                    children.Add(clone);
                }
            }

            return children.ToArray();
        }

        private bool checkWin(Tiles XorO)
        {
            if (tile[0] == XorO && tile[1] == XorO && tile[2] == XorO){
                return true;
            } else if (tile[3] == XorO && tile[4] == XorO && tile[5] == XorO)
            {
                return true;
            }else if (tile[6] == XorO && tile[7] == XorO && tile[8] == XorO)
            {
                return true;
            }else if (tile[0] == XorO && tile[3] == XorO && tile[6] == XorO)
            {
                return true;
            }else if (tile[1] == XorO && tile[4] == XorO && tile[7] == XorO)
            {
                return true;
            }else if (tile[2] == XorO && tile[5] == XorO && tile[8] == XorO)
            {
                return true;
            }else if (tile[0] == XorO && tile[4] == XorO && tile[8] == XorO) 
            {
                return true;
            }else if (tile[2] == XorO && tile[4] == XorO && tile[6] == XorO) 
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
