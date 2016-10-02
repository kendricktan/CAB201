namespace GameWorld
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CardRadioButton = new System.Windows.Forms.RadioButton();
            this.DiceRadioButton = new System.Windows.Forms.RadioButton();
            this.CoinRadioButton = new System.Windows.Forms.RadioButton();
            this.StartButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game World";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CardRadioButton);
            this.groupBox1.Controls.Add(this.DiceRadioButton);
            this.groupBox1.Controls.Add(this.CoinRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 96);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Game Type";
            // 
            // CardRadioButton
            // 
            this.CardRadioButton.AutoSize = true;
            this.CardRadioButton.Location = new System.Drawing.Point(6, 66);
            this.CardRadioButton.Name = "CardRadioButton";
            this.CardRadioButton.Size = new System.Drawing.Size(77, 17);
            this.CardRadioButton.TabIndex = 2;
            this.CardRadioButton.Text = "Card Game";
            this.CardRadioButton.UseVisualStyleBackColor = true;
            this.CardRadioButton.CheckedChanged += new System.EventHandler(this.GenericRadioButton_CheckedChanged);
            // 
            // DiceRadioButton
            // 
            this.DiceRadioButton.AutoSize = true;
            this.DiceRadioButton.Location = new System.Drawing.Point(6, 43);
            this.DiceRadioButton.Name = "DiceRadioButton";
            this.DiceRadioButton.Size = new System.Drawing.Size(76, 17);
            this.DiceRadioButton.TabIndex = 1;
            this.DiceRadioButton.Text = "Dice Game";
            this.DiceRadioButton.UseVisualStyleBackColor = true;
            this.DiceRadioButton.CheckedChanged += new System.EventHandler(this.GenericRadioButton_CheckedChanged);
            // 
            // CoinRadioButton
            // 
            this.CoinRadioButton.AutoSize = true;
            this.CoinRadioButton.Location = new System.Drawing.Point(6, 20);
            this.CoinRadioButton.Name = "CoinRadioButton";
            this.CoinRadioButton.Size = new System.Drawing.Size(76, 17);
            this.CoinRadioButton.TabIndex = 0;
            this.CoinRadioButton.Text = "Coin Game";
            this.CoinRadioButton.UseVisualStyleBackColor = true;
            this.CoinRadioButton.CheckedChanged += new System.EventHandler(this.GenericRadioButton_CheckedChanged);
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(12, 140);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(120, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "START";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 169);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(120, 23);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "EXIT";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(143, 206);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Games";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton CardRadioButton;
        private System.Windows.Forms.RadioButton DiceRadioButton;
        private System.Windows.Forms.RadioButton CoinRadioButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

