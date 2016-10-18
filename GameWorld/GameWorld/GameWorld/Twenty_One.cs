using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Low_Level_Objects_Library;

namespace GameWorld
{
    public partial class Twenty_One : Form
    {
        private CardPile Cardpile;
        private Hand PlayerHand;
        private Hand DealerHand;
        private int PlayerScore, PlayerGamesWon;
        private int DealerScore, DealerGamesWon;
        private int AceAsOne; 

        public Twenty_One()
        {
            InitializeComponent();
            
            this.PlayerScore = 0;
            this.PlayerGamesWon = 0;
            this.DealerScore = 0;
            this.DealerGamesWon = 0;
            this.AceAsOne = 0;

            this.hitButton.Enabled = false;
            this.standButton.Enabled = false;
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel)
        {
            tableLayoutPanel.Controls.Clear(); // Remove any cards already being shown.
            foreach (Card card in hand)
            {
                // Construct a PictureBox object.
                PictureBox pictureBox = new PictureBox();
                // Tell the PictureBox to use all the space inside its square.
                pictureBox.Dock = DockStyle.Fill;
                // Remove spacing around the PictureBox. (Default is 3 pixels.)
                pictureBox.Margin = new Padding(0);
                pictureBox.Image = Images.GetCardImage(card);
                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        private void testButton_Click(object sender, EventArgs e)
        {
            // New game m'dudes
            this.AceAsOne = 0;
            this.Cardpile = new CardPile(true);
            this.Cardpile.Shuffle();

            // New card piles
            PlayerHand = new Hand(Cardpile.DealCards(6));
            DealerHand = new Hand(Cardpile.DealCards(2));

            DisplayGuiHand(PlayerHand, playerTableLayoutPanel);
            DisplayGuiHand(DealerHand, dealerTableLayoutPanel);

            //this.dealButton.Enabled = false;
            this.hitButton.Enabled = true;
            this.standButton.Enabled = true;

            // If ace we ask if they wanna make ace have a value of 1            
            // and update score
            this.check_aces();
            this.update_game_score();
        }


        // Deals them cards
        private void dealButton_Click(object sender, EventArgs e)
        {
            // New game m'dudes
            this.DealerBustedLabel.Visible = false;
            this.PlayerBustedLabel.Visible = false;
            this.AceAsOne = 0;
            this.Cardpile = new CardPile(true);
            this.Cardpile.Shuffle();

            // New card piles
            PlayerHand = new Hand(Cardpile.DealCards(2));
            DealerHand = new Hand(Cardpile.DealCards(2));         

            DisplayGuiHand(PlayerHand, playerTableLayoutPanel);
            DisplayGuiHand(DealerHand, dealerTableLayoutPanel);

            this.dealButton.Enabled = false;
            this.hitButton.Enabled = true;
            this.standButton.Enabled = true;

            // If ace we ask if they wanna make ace have a value of 1            
            // and update score
            this.check_aces();
            this.update_game_score();
        }

        // Check em aces
        private void check_aces()
        {
            int temp_ace = this.AceAsOne;
            foreach (Card c in this.PlayerHand)
            {
                // Ace value is 11 by default
                if ((int)c.GetFaceValue() == 11)
                {
                    if (temp_ace == 0)
                    {
                        // Pop up message box
                        DialogResult rslt = MessageBox.Show("Count Aces as 1?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // If user wants to quit
                        if (rslt == DialogResult.Yes)
                        {
                            this.AceAsOne += 1;
                        }
                    }
                    else
                    {
                        temp_ace -= 1;
                    }
                }
            }
            this.AceValueOneLabel.Text = this.AceAsOne.ToString();
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            // Shuffle and get new card
            this.Cardpile.Shuffle();
            this.PlayerHand.Add(this.Cardpile.DealCards(1)[0]);

            // Update cards
            DisplayGuiHand(PlayerHand, playerTableLayoutPanel);
            DisplayGuiHand(DealerHand, dealerTableLayoutPanel);

            // Check for aces and update score
            this.check_aces();
            this.update_game_score();                       

            // Checks for busted, if busted player lost
            if (this.check_busted())
            {
                this.DealerGamesWon += 1;
                this.new_game();
                return;
            }            
        }

        // Now computer turn
        private void standButton_Click(object sender, EventArgs e)
        {
            // If dealer has 21, he wins immediately
            if (this.DealerScore == 21 && this.PlayerScore < 21)
            {
                this.DealerGamesWon += 1;
                this.new_game();
                return;
            }

            // If both 21, then new game
            if (this.DealerScore == 21 && this.PlayerScore == 21)
            {
                this.new_game();
                return;
            }

            // Keep drawing until reaches 17
            while (this.DealerScore < 17)
            {
                this.Cardpile.Shuffle();
                this.DealerHand.Add(this.Cardpile.DealCards(1)[0]);

                this.update_game_score();

                if (this.check_busted())
                {
                    this.PlayerGamesWon += 1;
                    this.new_game();
                    return;
                }
            }

            // Tries to keep drawing until is at least on par with player
            while(this.DealerScore < this.PlayerScore)
            {
                this.Cardpile.Shuffle();
                this.DealerHand.Add(this.Cardpile.DealCards(1)[0]);

                this.update_game_score();

                if (this.check_busted())
                {
                    this.PlayerGamesWon += 1;
                    this.new_game();
                    return;                   
                }
            }

            // If busted they should be taken care of by now
            // so if they end up here its just a matter of seeing who has
            // more points or are they equal
            if (this.PlayerScore < this.DealerScore)
            {
                this.DealerGamesWon += 1;
            }
            else if (this.DealerScore < this.PlayerScore)
            {
                this.PlayerGamesWon += 1;
            }            
            this.new_game();
        }

        // Check em cards
        private void update_game_score()
        {
            int aces_no = this.AceAsOne;
            int total_score = 0;
            foreach (Card c in this.PlayerHand)
            {
                // If not ace, we just add score
                // ace value is 11 by default
                if (!((int)c.GetFaceValue() == 11))
                {
                    total_score += (int)c.GetFaceValue();
                }

                // If ace, we check how many they wanted to be 1
                else
                {
                    // If we have aces that are '1'
                    if (aces_no > 0)
                    {
                        total_score += 1;
                        aces_no -= 1;
                    }
                    else
                    {
                        total_score += 11;
                    }
                }
            }
            this.PlayerScore = total_score;
            this.PlayerPointsLabel.Text = total_score.ToString();

            // Dealer score
            total_score = 0;
            foreach (Card c in this.DealerHand)
            {
                total_score += (int)c.GetFaceValue();
            }
            this.DealerScore = total_score;
            this.DealerPointsLabel.Text = total_score.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void Twenty_One_Load(object sender, EventArgs e)
        {

        }

        private void Twenty_One_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        // New game button settings
        public void new_game()
        {
            this.dealButton.Enabled = true;
            this.hitButton.Enabled = false;
            this.standButton.Enabled = false;

            this.PlayerGamesWonLabel.Text = this.PlayerGamesWon.ToString();
            this.DealerGamesWonLabel.Text = this.DealerGamesWon.ToString();

            // Update cards
            DisplayGuiHand(this.PlayerHand, this.playerTableLayoutPanel);
            DisplayGuiHand(this.DealerHand, this.dealerTableLayoutPanel);
        }        

        // Check game end or no
        private bool check_busted()
        {
            if (this.PlayerScore > 21)
            {
                this.PlayerBustedLabel.Visible = true;
                return true;
            }
            if (this.DealerScore > 21)
            {
                this.DealerBustedLabel.Visible = true;
                return true;
            }

            return false;
        }
    }
}
