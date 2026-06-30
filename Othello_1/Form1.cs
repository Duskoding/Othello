using System.Windows.Forms;

namespace Othello_1
{
    public partial class Form1 : Form
    {
        PictureBox[,] board;
        const int SIZE = 8;

        public Form1()
        {
            InitializeComponent();
            PaintBoard();
        }

        void PaintBoard()
        {
            board = new PictureBox[SIZE, SIZE];
            for (int row = 0; row < SIZE; ++row)
            {
                for (int col = 0; col < SIZE; ++col)
                {
                    PictureBox pb = new PictureBox();
                    pb.BackColor = pbModel.BackColor;
                    pb.Size = pbModel.Size;
                    pb.Image = pbModel.Image;

                    board[row, col] = pb;

                    pb.Location = new Point(row * 60, col * 60);
                    int[] arr = { row, col };
                    pb.Tag = arr;
                    pb.Click += (s, e) => { BoxClicked(s, e); };
                    gbBoard.Controls.Add(pb);
                }
                gbBoard.Refresh();
            }

        }
        void BoxClicked(object sender, EventArgs e)
        {
            int dummy = 0;
            PictureBox pb = (PictureBox)sender;
            var location = pb.Tag;

            if (location is int[] arr && arr.Length >= 2)
            {
                int row = arr[0];
                int col = arr[1];
                board[row, col].Image = pbBlack.Image;
            }

        }
    }
}
