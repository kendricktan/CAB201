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
using Low_Level_Objects_Library;

namespace GameWorld
{
    public partial class Snake_Eyes : Form
    {
        private int TIMER_FIRST_ROLL_NO = 0;
        private int TIMER_CONTINUE_ROLL_NO = 0;
        private Random rnd = new Random();

        public Snake_Eyes()
        {
            InitializeComponent();

            // Initialize em dices
            Snake_Eyes_Game.SetUpGame();

            UpdatePictureBoxImage(pictureBox1, Snake_Eyes_Game.GetDiceFaceValue(0));
            UpdatePictureBoxImage(pictureBox2, Snake_Eyes_Game.GetDiceFaceValue(1));
        }

        private void UpdatePictureBoxImage(PictureBox whichPB, int faceValue)
        {
            whichPB.Image = Images.GetDieImage(faceValue);
        }

        private void CancelGameButton_Click(object sender, EventArgs e)
        {
            // Pop up message box
            if (Snake_Eyes_Game.GetPlayersPoints() > Snake_Eyes_Game.GetHousePoints())
            {
                MessageBox.Show("You won! Well done");
            }
            if (Snake_Eyes_Game.GetPlayersPoints() < Snake_Eyes_Game.GetHousePoints())
            {
                MessageBox.Show("House won! Better luck next time");
            }
            if (Snake_Eyes_Game.GetPlayersPoints() == Snake_Eyes_Game.GetHousePoints())
            {
                MessageBox.Show("It was a draw!");
            }

            this.Visible = false;            
        }

        // First roll
        private void RollButton_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
            this.RollButton.Enabled = false;
        }

        // Etc rolls
        private void ContPlayingButton_Click(object sender, EventArgs e)
        {
            this.timer2.Enabled = true;
            this.ContPlayingButton.Enabled = false;
        }

        private void Snake_Eyes_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TIMER_FIRST_ROLL_NO += 1;

            if (TIMER_FIRST_ROLL_NO >= 10)
            {
                bool again = Snake_Eyes_Game.FirstRoll();

                if (again)
                {
                    this.RollButton.Enabled = false;
                    this.ContPlayingButton.Enabled = true;

                    this.placeholderLabel.Text = "you need to roll " + Snake_Eyes_Game.GetPossiblePoints().ToString() + " points";
                    this.StatusLabel.Text = "Roll again";
                }

                if (!again)
                {
                    this.StatusLabel.Text = Snake_Eyes_Game.GetRollOutcome();

                    if (Snake_Eyes_Game.GetRollTotal() == 2)
                    {
                        this.placeholderLabel.Text = "You get 2 points";
                    }
                    if (Snake_Eyes_Game.GetRollTotal() == 7 || Snake_Eyes_Game.GetRollTotal() == 11)
                    {
                        this.placeholderLabel.Text = "You get 1 point";
                    }
                    if (Snake_Eyes_Game.GetRollTotal() == 3 || Snake_Eyes_Game.GetRollTotal() == 12)
                    {
                        this.placeholderLabel.Text = "House gets 2 points";
                    }

                    this.RollButton.Enabled = true;
                }

                this.PlayerScoreLabel.Text = Snake_Eyes_Game.GetPlayersPoints().ToString();
                this.HouseScoreLabel.Text = Snake_Eyes_Game.GetHousePoints().ToString();

                UpdatePictureBoxImage(pictureBox1, Snake_Eyes_Game.GetDiceFaceValue(0));
                UpdatePictureBoxImage(pictureBox2, Snake_Eyes_Game.GetDiceFaceValue(1));

                TIMER_FIRST_ROLL_NO = 0;
                this.timer1.Enabled = false;
            }
            else
            {
                UpdatePictureBoxImage(pictureBox1, rnd.Next(1, 7));
                UpdatePictureBoxImage(pictureBox2, rnd.Next(1, 7));
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TIMER_CONTINUE_ROLL_NO += 1;

            if (TIMER_CONTINUE_ROLL_NO >= 10)
            {
                bool again = Snake_Eyes_Game.AnotherRoll();

                if (!again)
                {
                    this.StatusLabel.Text = Snake_Eyes_Game.GetRollOutcome();

                    // House gains point
                    if (Snake_Eyes_Game.GetRollOutcome().Contains("lost"))
                    {
                        this.placeholderLabel.Text = "House got 2 points!";
                    }
                    else
                    {
                        this.placeholderLabel.Text = "You get " + Snake_Eyes_Game.GetPossiblePoints().ToString() + " points";
                    }

                    this.ContPlayingButton.Enabled = false;
                    this.RollButton.Enabled = true;
                }
                else
                {
                    this.ContPlayingButton.Enabled = true;
                }

                this.PlayerScoreLabel.Text = Snake_Eyes_Game.GetPlayersPoints().ToString();
                this.HouseScoreLabel.Text = Snake_Eyes_Game.GetHousePoints().ToString();

                UpdatePictureBoxImage(pictureBox1, Snake_Eyes_Game.GetDiceFaceValue(0));
                UpdatePictureBoxImage(pictureBox2, Snake_Eyes_Game.GetDiceFaceValue(1));

                TIMER_CONTINUE_ROLL_NO = 0;
                this.timer2.Enabled = false;
            }
            else
            {
                UpdatePictureBoxImage(pictureBox1, rnd.Next(1, 7));
                UpdatePictureBoxImage(pictureBox2, rnd.Next(1, 7));
            }
        }
    }
}
