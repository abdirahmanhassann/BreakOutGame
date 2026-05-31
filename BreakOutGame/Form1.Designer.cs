namespace BreakOutGame
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
            paddlePictureBox = new PictureBox();
            ballPictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)paddlePictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ballPictureBox).BeginInit();
            SuspendLayout();
            // 
            // paddlePictureBox
            // 
            paddlePictureBox.BackColor = SystemColors.ControlText;
            paddlePictureBox.Location = new Point(323, 475);
            paddlePictureBox.Name = "paddlePictureBox";
            paddlePictureBox.Size = new Size(140, 13);
            paddlePictureBox.TabIndex = 0;
            paddlePictureBox.TabStop = false;
            // 
            // ballPictureBox
            // 
            ballPictureBox.BackColor = Color.FromArgb(0, 64, 0);
            ballPictureBox.Location = new Point(345, 151);
            ballPictureBox.Name = "ballPictureBox";
            ballPictureBox.Size = new Size(18, 18);
            ballPictureBox.TabIndex = 1;
            ballPictureBox.TabStop = false;
            ballPictureBox.Click += ballPictureBox_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(ballPictureBox);
            Controls.Add(paddlePictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)paddlePictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ballPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox paddlePictureBox;
        private PictureBox ballPictureBox;
        private PictureBox pictureBox1;
    }
}
