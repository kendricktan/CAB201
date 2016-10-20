using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Games_Logic_Library;

namespace GameWorld
{
    public partial class Two_Up : Form
    {
        // How many times has the timer ticked
        private int TIMER_TICK_TIME = 0;

        public Two_Up()
        {
            InitializeComponent();

            Two_Up_Game.SetUpGame();

            UpdatePictureBoxImage(pictureBox1, Two_Up_Game.IsHeads(1));
            UpdatePictureBoxImage(pictureBox2, Two_Up_Game.IsHeads(2));
        }

        // Disables closing of form
        private void Two_Up_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void UpdatePictureBoxImage(PictureBox whichPB, bool isHeads)
        {
            whichPB.Image = Images.GetCoinImage(isHeads);
        }

        private void CancelGameButton_Click(object sender, EventArgs e)
        {
            // Pop up message box
            DialogResult rslt = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user wants to quit
            if (rslt == DialogResult.Yes)
            {
                this.Visible = false;
            }        
        }

        private void ThrowCoinsButton_Click(object sender, EventArgs e)
        {
            // Toss coins
            Two_Up_Game.TossCoins();

            // Disable button
            this.ThrowCoinsButton.Enabled = false;

            // Call timer
            this.timer1.Enabled = true;                     
        }

        // Play again
        private void PlayAgainButton_Click(object sender, EventArgs e)
        {
            this.ThrowCoinsButton.Enabled = true;
            this.PlayAgainButton.Visible = false;            
        }

        // Timers brah
        private void timer1_Tick(object sender, EventArgs e)
        {
            TIMER_TICK_TIME += 1;
            if (TIMER_TICK_TIME >= 10)
            {
                this.ThrowCoinsButton.Enabled = true;
                this.timer1.Enabled = false;

                // Update pictures
                UpdatePictureBoxImage(pictureBox1, Two_Up_Game.IsHeads(1));
                UpdatePictureBoxImage(pictureBox2, Two_Up_Game.IsHeads(2));

                // Get result
                string result = Two_Up_Game.TossOutCome();
                this.OutcomeLabel.Text = result;

                // Scoring
                this.PlayerScoreLabel.Text = Two_Up_Game.GetPlayersScore().ToString();
                this.ComputerScoreLabel.Text = Two_Up_Game.GetComputersScore().ToString();

                // Determine next step
                if (result == "Heads" || result == "Tails")
                {
                    this.ThrowCoinsButton.Enabled = false;
                    this.PlayAgainButton.Visible = true;
                }

                TIMER_TICK_TIME = 0;
            }
            else
            {
                // Animation
                if (TIMER_TICK_TIME % 2 == 0)
                {
                    UpdatePictureBoxImage(pictureBox1, Two_Up_Game.IsHeads(1));
                    UpdatePictureBoxImage(pictureBox2, Two_Up_Game.IsHeads(2));
                }
                else
                {
                    UpdatePictureBoxImage(pictureBox1, !Two_Up_Game.IsHeads(1));
                    UpdatePictureBoxImage(pictureBox2, !Two_Up_Game.IsHeads(2));
                }
            }
        }
    }
}
