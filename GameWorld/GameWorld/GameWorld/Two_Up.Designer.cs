namespace GameWorld
{
    partial class Two_Up
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PlayerLabel = new System.Windows.Forms.Label();
            this.ComputerLabel = new System.Windows.Forms.Label();
            this.PlayerScoreLabel = new System.Windows.Forms.Label();
            this.ComputerScoreLabel = new System.Windows.Forms.Label();
            this.OutcomeLabel = new System.Windows.Forms.Label();
            this.ThrowCoinsButton = new System.Windows.Forms.Button();
            this.PlayAgainButton = new System.Windows.Forms.Button();
            this.CancelGameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(226, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 150);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // PlayerLabel
            // 
            this.PlayerLabel.AutoSize = true;
            this.PlayerLabel.Location = new System.Drawing.Point(9, 239);
            this.PlayerLabel.Name = "PlayerLabel";
            this.PlayerLabel.Size = new System.Drawing.Size(72, 13);
            this.PlayerLabel.TabIndex = 2;
            this.PlayerLabel.Text = "Player\'s Score";
            // 
            // ComputerLabel
            // 
            this.ComputerLabel.AutoSize = true;
            this.ComputerLabel.Location = new System.Drawing.Point(223, 239);
            this.ComputerLabel.Name = "ComputerLabel";
            this.ComputerLabel.Size = new System.Drawing.Size(89, 13);
            this.ComputerLabel.TabIndex = 3;
            this.ComputerLabel.Text = "Computer\'s Score";
            // 
            // PlayerScoreLabel
            // 
            this.PlayerScoreLabel.AutoSize = true;
            this.PlayerScoreLabel.BackColor = System.Drawing.Color.White;
            this.PlayerScoreLabel.Location = new System.Drawing.Point(87, 239);
            this.PlayerScoreLabel.Name = "PlayerScoreLabel";
            this.PlayerScoreLabel.Size = new System.Drawing.Size(13, 13);
            this.PlayerScoreLabel.TabIndex = 4;
            this.PlayerScoreLabel.Text = "0";
            // 
            // ComputerScoreLabel
            // 
            this.ComputerScoreLabel.AutoSize = true;
            this.ComputerScoreLabel.BackColor = System.Drawing.Color.White;
            this.ComputerScoreLabel.Location = new System.Drawing.Point(318, 239);
            this.ComputerScoreLabel.Name = "ComputerScoreLabel";
            this.ComputerScoreLabel.Size = new System.Drawing.Size(13, 13);
            this.ComputerScoreLabel.TabIndex = 5;
            this.ComputerScoreLabel.Text = "0";
            // 
            // OutcomeLabel
            // 
            this.OutcomeLabel.AutoSize = true;
            this.OutcomeLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutcomeLabel.Location = new System.Drawing.Point(161, 9);
            this.OutcomeLabel.Name = "OutcomeLabel";
            this.OutcomeLabel.Size = new System.Drawing.Size(0, 26);
            this.OutcomeLabel.TabIndex = 6;
            // 
            // ThrowCoinsButton
            // 
            this.ThrowCoinsButton.Location = new System.Drawing.Point(12, 292);
            this.ThrowCoinsButton.Name = "ThrowCoinsButton";
            this.ThrowCoinsButton.Size = new System.Drawing.Size(107, 23);
            this.ThrowCoinsButton.TabIndex = 7;
            this.ThrowCoinsButton.Text = "Throw Coins";
            this.ThrowCoinsButton.UseVisualStyleBackColor = true;
            this.ThrowCoinsButton.Click += new System.EventHandler(this.ThrowCoinsButton_Click);
            // 
            // PlayAgainButton
            // 
            this.PlayAgainButton.Location = new System.Drawing.Point(141, 292);
            this.PlayAgainButton.Name = "PlayAgainButton";
            this.PlayAgainButton.Size = new System.Drawing.Size(107, 23);
            this.PlayAgainButton.TabIndex = 8;
            this.PlayAgainButton.Text = "Play Again";
            this.PlayAgainButton.UseVisualStyleBackColor = true;
            this.PlayAgainButton.Visible = false;
            this.PlayAgainButton.Click += new System.EventHandler(this.PlayAgainButton_Click);
            // 
            // CancelGameButton
            // 
            this.CancelGameButton.Location = new System.Drawing.Point(269, 292);
            this.CancelGameButton.Name = "CancelGameButton";
            this.CancelGameButton.Size = new System.Drawing.Size(107, 23);
            this.CancelGameButton.TabIndex = 9;
            this.CancelGameButton.Text = "Cancel Game";
            this.CancelGameButton.UseVisualStyleBackColor = true;
            this.CancelGameButton.Click += new System.EventHandler(this.CancelGameButton_Click);
            // 
            // Two_Up
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 331);
            this.Controls.Add(this.CancelGameButton);
            this.Controls.Add(this.PlayAgainButton);
            this.Controls.Add(this.ThrowCoinsButton);
            this.Controls.Add(this.OutcomeLabel);
            this.Controls.Add(this.ComputerScoreLabel);
            this.Controls.Add(this.PlayerScoreLabel);
            this.Controls.Add(this.ComputerLabel);
            this.Controls.Add(this.PlayerLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Two_Up";
            this.Text = "Two_Up";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Two_Up_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label PlayerLabel;
        private System.Windows.Forms.Label ComputerLabel;
        private System.Windows.Forms.Label PlayerScoreLabel;
        private System.Windows.Forms.Label ComputerScoreLabel;
        private System.Windows.Forms.Label OutcomeLabel;
        private System.Windows.Forms.Button ThrowCoinsButton;
        private System.Windows.Forms.Button PlayAgainButton;
        private System.Windows.Forms.Button CancelGameButton;
    }
}