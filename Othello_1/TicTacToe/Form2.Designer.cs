using Othello_1;

namespace Othello_1.TicTacToe
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            gbBoard = new GroupBox();
            pbModel = new PictureBox();
            pbO = new PictureBox();
            pbX = new PictureBox();
            Restart = new Button();
            numericUpDown1 = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)pbModel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbO).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
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
            // pbModel
            // 
            pbModel.Anchor = AnchorStyles.None;
            pbModel.BackColor = SystemColors.ControlDark;
            pbModel.Image = Properties.Resources.pbModel;
            pbModel.Location = new Point(1166, 395);
            pbModel.Name = "pbModel";
            pbModel.Size = new Size(200, 200);
            pbModel.SizeMode = PictureBoxSizeMode.StretchImage;
            pbModel.TabIndex = 0;
            pbModel.TabStop = false;
            pbModel.Visible = false;
            // 
            // pbO
            // 
            pbO.Anchor = AnchorStyles.None;
            pbO.Image = Properties.Resources.O;
            pbO.Location = new Point(1166, 200);
            pbO.Name = "pbO";
            pbO.Size = new Size(200, 200);
            pbO.SizeMode = PictureBoxSizeMode.Zoom;
            pbO.TabIndex = 0;
            pbO.TabStop = false;
            pbO.Visible = false;
            // 
            // pbX
            // 
            pbX.Anchor = AnchorStyles.None;
            pbX.Image = Properties.Resources.X;
            pbX.Location = new Point(1166, -2);
            pbX.Name = "pbX";
            pbX.Size = new Size(200, 200);
            pbX.SizeMode = PictureBoxSizeMode.Zoom;
            pbX.TabIndex = 2;
            pbX.TabStop = false;
            pbX.Visible = false;
            // 
            // Restart
            // 
            Restart.Anchor = AnchorStyles.None;
            Restart.AutoSize = true;
            Restart.BackColor = Color.Tomato;
            Restart.Location = new Point(16, 55);
            Restart.Name = "Restart";
            Restart.Size = new Size(120, 80);
            Restart.TabIndex = 3;
            Restart.Text = "Restart";
            Restart.UseVisualStyleBackColor = false;
            Restart.Click += restartClick;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.None;
            numericUpDown1.AutoSize = true;
            numericUpDown1.Location = new Point(16, 151);
            numericUpDown1.Maximum = new decimal(new int[] { 9, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(106, 47);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += NumericUpDown_ValueChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1368, 1312);
            Controls.Add(numericUpDown1);
            Controls.Add(Restart);
            Controls.Add(pbModel);
            Controls.Add(pbX);
            Controls.Add(pbO);
            Controls.Add(gbBoard);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pbModel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbO).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pbModel;
        private PictureBox pbO;
        private GroupBox gbBoard;
        private PictureBox pbX;
        private Button Restart;
        private NumericUpDown numericUpDown1;
    }
}