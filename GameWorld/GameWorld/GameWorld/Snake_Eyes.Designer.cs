namespace GameWorld
{
    partial class Snake_Eyes
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.RollButton = new System.Windows.Forms.Button();
            this.placeholderLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PlayerScoreLabel = new System.Windows.Forms.Label();
            this.HouseScoreLabel = new System.Windows.Forms.Label();
            this.ContPlayingButton = new System.Windows.Forms.Button();
            this.CancelGameButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(289, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(78, 12);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(205, 13);
            this.StatusLabel.TabIndex = 2;
            this.StatusLabel.Text = "First Roll";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RollButton
            // 
            this.RollButton.Location = new System.Drawing.Point(81, 49);
            this.RollButton.Name = "RollButton";
            this.RollButton.Size = new System.Drawing.Size(202, 23);
            this.RollButton.TabIndex = 3;
            this.RollButton.Text = "Roll Dice";
            this.RollButton.UseVisualStyleBackColor = true;
            this.RollButton.Click += new System.EventHandler(this.RollButton_Click);
            // 
            // placeholderLabel
            // 
            this.placeholderLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderLabel.Location = new System.Drawing.Point(12, 84);
            this.placeholderLabel.Name = "placeholderLabel";
            this.placeholderLabel.Size = new System.Drawing.Size(337, 20);
            this.placeholderLabel.TabIndex = 4;
            this.placeholderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Player\'s Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "House Score";
            // 
            // PlayerScoreLabel
            // 
            this.PlayerScoreLabel.AutoSize = true;
            this.PlayerScoreLabel.BackColor = System.Drawing.Color.White;
            this.PlayerScoreLabel.Location = new System.Drawing.Point(91, 113);
            this.PlayerScoreLabel.Name = "PlayerScoreLabel";
            this.PlayerScoreLabel.Size = new System.Drawing.Size(13, 13);
            this.PlayerScoreLabel.TabIndex = 7;
            this.PlayerScoreLabel.Text = "0";
            // 
            // HouseScoreLabel
            // 
            this.HouseScoreLabel.AutoSize = true;
            this.HouseScoreLabel.BackColor = System.Drawing.Color.White;
            this.HouseScoreLabel.Location = new System.Drawing.Point(336, 113);
            this.HouseScoreLabel.Name = "HouseScoreLabel";
            this.HouseScoreLabel.Size = new System.Drawing.Size(13, 13);
            this.HouseScoreLabel.TabIndex = 8;
            this.HouseScoreLabel.Text = "0";
            // 
            // ContPlayingButton
            // 
            this.ContPlayingButton.Enabled = false;
            this.ContPlayingButton.Location = new System.Drawing.Point(12, 139);
            this.ContPlayingButton.Name = "ContPlayingButton";
            this.ContPlayingButton.Size = new System.Drawing.Size(113, 23);
            this.ContPlayingButton.TabIndex = 9;
            this.ContPlayingButton.Text = "Continue Playing";
            this.ContPlayingButton.UseVisualStyleBackColor = true;
            this.ContPlayingButton.Click += new System.EventHandler(this.ContPlayingButton_Click);
            // 
            // CancelGameButton
            // 
            this.CancelGameButton.Location = new System.Drawing.Point(238, 139);
            this.CancelGameButton.Name = "CancelGameButton";
            this.CancelGameButton.Size = new System.Drawing.Size(113, 23);
            this.CancelGameButton.TabIndex = 10;
            this.CancelGameButton.Text = "Cancel Game";
            this.CancelGameButton.UseVisualStyleBackColor = true;
            this.CancelGameButton.Click += new System.EventHandler(this.CancelGameButton_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Snake_Eyes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 169);
            this.Controls.Add(this.CancelGameButton);
            this.Controls.Add(this.ContPlayingButton);
            this.Controls.Add(this.HouseScoreLabel);
            this.Controls.Add(this.PlayerScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.placeholderLabel);
            this.Controls.Add(this.RollButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Snake_Eyes";
            this.Text = "Snake_Eyes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Snake_Eyes_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button RollButton;
        private System.Windows.Forms.Label placeholderLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PlayerScoreLabel;
        private System.Windows.Forms.Label HouseScoreLabel;
        private System.Windows.Forms.Button ContPlayingButton;
        private System.Windows.Forms.Button CancelGameButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}