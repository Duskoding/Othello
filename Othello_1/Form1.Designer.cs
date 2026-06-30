using System.Windows.Forms;
using System.Xml.Linq;

namespace Othello_1
 
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pbModel = new PictureBox();
            gbBoard = new GroupBox();
            pbBlack = new PictureBox();
            pbWhite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbModel).BeginInit();
            gbBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBlack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWhite).BeginInit();
            SuspendLayout();
            // 
            // pbModel
            // 
            pbModel.BackColor = Color.FromArgb(0, 64, 0);
            pbModel.Image = (Image)resources.GetObject("pbModel.Image");
            pbModel.Location = new Point(75, 64);
            pbModel.Name = "pbModel";
            pbModel.Size = new Size(60, 60);
            pbModel.TabIndex = 0;
            pbModel.TabStop = false;
            pbModel.Visible = false;
            // 
            // gbBoard
            // 
            gbBoard.Controls.Add(pbBlack);
            gbBoard.Controls.Add(pbWhite);
            gbBoard.Controls.Add(pbModel);
            gbBoard.Location = new Point(41, 12);
            gbBoard.Name = "gbBoard";
            gbBoard.Size = new Size(500, 500);
            gbBoard.TabIndex = 1;
            gbBoard.TabStop = false;
            gbBoard.Text = "groupBox1";
            // 
            // pbBlack
            // 
            pbBlack.BackColor = Color.FromArgb(0, 64, 0);
            pbBlack.Image = (Image)resources.GetObject("pbBlack.Image");
            pbBlack.Location = new Point(187, 304);
            pbBlack.Name = "pbBlack";
            pbBlack.Size = new Size(60, 60);
            pbBlack.TabIndex = 2;
            pbBlack.TabStop = false;
            pbBlack.Visible = false;
            // 
            // pbWhite
            // 
            pbWhite.BackColor = Color.FromArgb(0, 64, 0);
            pbWhite.Image = (Image)resources.GetObject("pbWhite.Image");
            pbWhite.Location = new Point(259, 219);
            pbWhite.Name = "pbWhite";
            pbWhite.Size = new Size(60, 60);
            pbWhite.TabIndex = 1;
            pbWhite.TabStop = false;
            pbWhite.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 561);
            Controls.Add(gbBoard);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbModel).EndInit();
            gbBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbBlack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWhite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbModel;
        private GroupBox gbBoard;
        private PictureBox pbWhite;
        private PictureBox pbBlack;
    }
}
