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
            gbBoard = new GroupBox();
            numericUpDown1 = new NumericUpDown();
            pbModel = new PictureBox();
            pbBlack = new PictureBox();
            pbWhite = new PictureBox();
            Restart = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbModel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBlack).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbWhite).BeginInit();
            SuspendLayout();
            // 
            // gbBoard
            // 
            gbBoard.Anchor = AnchorStyles.None;
            gbBoard.AutoSize = true;
            gbBoard.Location = new Point(200, 100);
            gbBoard.Margin = new Padding(7, 8, 7, 8);
            gbBoard.Name = "gbBoard";
            gbBoard.Padding = new Padding(7, 8, 7, 8);
            gbBoard.Size = new Size(1000, 1000);
            gbBoard.TabIndex = 1;
            gbBoard.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.None;
            numericUpDown1.AutoSize = true;
            numericUpDown1.Location = new Point(58, 198);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(106, 47);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown1.ValueChanged += NumericUpDown_ValueChanged;
            // 
            // pbModel
            // 
            pbModel.Anchor = AnchorStyles.None;
            pbModel.BackColor = Color.DarkGreen;
            pbModel.Image = Properties.Resources.pbModel;
            pbModel.Location = new Point(1210, 141);
            pbModel.Name = "pbModel";
            pbModel.Size = new Size(120, 120);
            pbModel.SizeMode = PictureBoxSizeMode.Zoom;
            pbModel.TabIndex = 3;
            pbModel.TabStop = false;
            pbModel.Visible = false;
            // 
            // pbBlack
            // 
            pbBlack.Anchor = AnchorStyles.None;
            pbBlack.Image = Properties.Resources.O_Black;
            pbBlack.Location = new Point(1210, 290);
            pbBlack.Name = "pbBlack";
            pbBlack.Size = new Size(120, 120);
            pbBlack.SizeMode = PictureBoxSizeMode.Zoom;
            pbBlack.TabIndex = 4;
            pbBlack.TabStop = false;
            pbBlack.Visible = false;
            // 
            // pbWhite
            // 
            pbWhite.Anchor = AnchorStyles.None;
            pbWhite.Image = Properties.Resources.O_White;
            pbWhite.Location = new Point(1210, 457);
            pbWhite.Name = "pbWhite";
            pbWhite.Size = new Size(120, 120);
            pbWhite.SizeMode = PictureBoxSizeMode.Zoom;
            pbWhite.TabIndex = 5;
            pbWhite.TabStop = false;
            pbWhite.Visible = false;
            // 
            // Restart
            // 
            Restart.Anchor = AnchorStyles.None;
            Restart.AutoSize = true;
            Restart.BackColor = Color.Tomato;
            Restart.Location = new Point(58, 100);
            Restart.Name = "Restart";
            Restart.Size = new Size(120, 80);
            Restart.TabIndex = 6;
            Restart.Text = "Restart";
            Restart.UseVisualStyleBackColor = false;
            Restart.Click += restartClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 1312);
            Controls.Add(Restart);
            Controls.Add(pbWhite);
            Controls.Add(pbBlack);
            Controls.Add(pbModel);
            Controls.Add(numericUpDown1);
            Controls.Add(gbBoard);
            Margin = new Padding(7, 8, 7, 8);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbModel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBlack).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbWhite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox gbBoard;
        private NumericUpDown numericUpDown1;
        private PictureBox pbModel;
        private PictureBox pbBlack;
        private PictureBox pbWhite;
        private Button Restart;
    }
}
