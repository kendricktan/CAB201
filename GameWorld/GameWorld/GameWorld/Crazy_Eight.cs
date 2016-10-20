using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Low_Level_Objects_Library;

namespace GameWorld
{
    public partial class Crazy_Eight : Form
    {
        private Form chooseSuitForm;
        private CardPile Cardpile;
        private Hand PileHand;
        private Hand PlayerHand;
        private Hand ComputerHand;
        private bool UseCustomSuitValue = false;
        public Suit CustomSuitValue;
        public bool AnySuit = false; // Only enable when first card down is eight of suits

        public Crazy_Eight()
        {
            InitializeComponent();

            this.drawPilePictureBox.Image = Images.GetBackOfCardImage();

            this.statusLabel.Text = "Click Deal to start the game.";

            chooseSuitForm = new ChooseSuitForm(this);
        }

        private void DisplayGuiHand(Hand hand, TableLayoutPanel tableLayoutPanel, int who)
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

                // Add event handler for that card
                // Computer is player 1      
                // User is player 2
                if (who == 2)
                {
                    // Set event-handler for Click on this PictureBox
                    pictureBox.Click += new EventHandler(pictureBox_Click);

                    // Tell the PictureBox which card object it is a picture of
                    pictureBox.Tag = card;
                }

                // Add the PictureBox object to the tableLayoutPanel.
                tableLayoutPanel.Controls.Add(pictureBox);
            }
        }// End DisplayGuiHand

        private void pictureBox_Click(object sender, EventArgs e)
        {
            // Which Card was clicked?
            PictureBox cpb = (PictureBox)sender;
            Card cc = (Card)cpb.Tag;

            TryToPlayCard(cc);        
            
            if (this.PlayerHand.GetCount() == 0)
            {
                this.statusLabel.Text = "You won! Congratluations!";
                this.dealButton.Enabled = true;
                this.sortCardButton.Enabled = false;
            }      
            else if (this.ComputerHand.GetCount() == 0)
            {
                this.statusLabel.Text = "Better luck next time!";
                this.dealButton.Enabled = true;
                this.sortCardButton.Enabled = false;
            }          
        }

        private void TryToPlayCard(Card clickedCard)
        {
            // Crazy eight
            if (clickedCard.GetFaceValue() == FaceValue.Eight)
            {
                this.chooseSuitForm.Visible = true;
                this.chooseSuitForm.Show();                

                this.PlayerHand.Remove(clickedCard);
                this.PileHand.Add(clickedCard);
                this.updatePileHandPicture();
                DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);

                this.UseCustomSuitValue = true;
            }
            // Can play if card values are the same
            else if (clickedCard.GetFaceValue() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetFaceValue()
                || (!UseCustomSuitValue && clickedCard.GetSuit() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetSuit())
                || (UseCustomSuitValue && clickedCard.GetSuit() == this.CustomSuitValue)
                || AnySuit)
            {
                this.PlayerHand.Remove(clickedCard);
                this.PileHand.Add(clickedCard);
                this.updatePileHandPicture();
                DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);

                // Played cards, so custom suit value is no more
                this.UseCustomSuitValue = false;

                // Computer's turn
                this.ComputerPlay();

                // Anysuit is turned off then
                this.AnySuit = false;
            }            
            else
            {
                this.statusLabel.Text = "Can't play that card now.";
            }
        }

        // Computer Playing
        public void ComputerPlay()
        {
            // Add a delay
            RefreshTheFormThenPause();

            // Keep drawing cards until computer plays
            while (!CanComputerPlay() && ComputerHand.GetCount() < 13)
            {
                try
                {
                    this.ComputerHand.Add(this.Cardpile.DealOneCard());
                }
                catch
                {
                    // Can't add? pile is probably empty lol
                    this.NewPlayingCardPile();
                    this.ComputerHand.Add(this.Cardpile.DealOneCard());
                }
            }

            // Just plays the first playable card (FaceValue first)     
            bool Played = false;     
            foreach (Card c in this.ComputerHand)
            {               
                if (c.GetFaceValue() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetFaceValue())
                {
                    this.ComputerHand.Remove(c);
                    this.PileHand.Add(c);
                    this.updatePileHandPicture();
                    DisplayGuiHand(this.ComputerHand, this.tableLayoutPanel1, 1);

                    UseCustomSuitValue = false;
                    Played = true;
                    break;
                }
            }

            // Suit
            if (!Played)
            {
                foreach (Card c in this.ComputerHand)
                {
                    if ((!UseCustomSuitValue && c.GetSuit() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetSuit()) ||
                        (UseCustomSuitValue && c.GetSuit() == this.CustomSuitValue))
                    {
                        this.ComputerHand.Remove(c);
                        this.PileHand.Add(c);
                        this.updatePileHandPicture();
                        DisplayGuiHand(this.ComputerHand, this.tableLayoutPanel1, 1);

                        UseCustomSuitValue = false;
                        Played = true;
                        break;
                    }
                }
            }

            // 8
            if (!Played)
            {
                foreach (Card c in this.ComputerHand)
                {
                    if (c.GetFaceValue() == FaceValue.Eight)
                    {
                        this.ComputerHand.Remove(c);
                        this.PileHand.Add(c);
                        this.updatePileHandPicture();
                        DisplayGuiHand(this.ComputerHand, this.tableLayoutPanel1, 1);

                        UseCustomSuitValue = false;
                        Played = true;
                        break;
                    }
                }
            }

            // Output text
            this.statusLabel.Text = "Your turn. Click on one of your cards to play.";

            // Checks if user can play
            if (!CanPlayerPlay())
            {
                this.statusLabel.Text = "You have no cards that you can play. You must draw a card.";

                // If both player's can't play then its a tie
                if (!CanComputerPlay())
                {
                    this.statusLabel.Text = "It's a tie!";
                    this.dealButton.Enabled = true;
                    this.sortCardButton.Enabled = false;
                }

                // If user can't play and user has 13 cards, just play again
                if (this.PlayerHand.GetCount() >= 13)
                {
                    ComputerPlay();
                }
            }
        }

        // Refresh form via multi-threading
        private static void RefreshTheFormThenPause()
        {
            // form display any recent changes to any controls
            Application.DoEvents();

            // Wait, then continue            
            Thread.Sleep(500);
        }

        // Deals card
        private void dealButton_Click(object sender, EventArgs e)
        {
            // Init new card piles
            this.Cardpile = new CardPile(true);
            this.Cardpile.Shuffle();

            this.PlayerHand = new Hand(this.Cardpile.DealCards(8));
            this.ComputerHand = new Hand(this.Cardpile.DealCards(8));
            this.PileHand = new Hand(this.Cardpile.DealCards(1));

            // If first card is 8, any value is allowed
            if (this.PileHand.GetCard(0).GetFaceValue() == FaceValue.Eight)
            {
                AnySuit = true;
            }

            DisplayGuiHand(this.ComputerHand, this.tableLayoutPanel1, 1);
            DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);

            // Update pile iamges 
            this.updatePileHandPicture();            

            this.dealButton.Enabled = false;
            this.sortCardButton.Enabled = true;

            // Update status label
            this.statusLabel.Text = "Your turn. Click on one of your cards to play.";
        }

        // Update pile hand image
        private void updatePileHandPicture()
        {
            this.pileHandPictureBox.Image = Images.GetCardImage(this.PileHand.GetCard(this.PileHand.GetCount() - 1));
        }

        // Sort play's card
        private void sortCardButton_Click(object sender, EventArgs e)
        {
            if (this.PlayerHand != null)
            {
                this.PlayerHand.Sort();
                DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);
            }
        }

        // Get New card
        private void drawPilePictureBox_Click(object sender, EventArgs e)
        {
            // If card pile is not none
            if (this.Cardpile != null)
            {
                if (this.CanPlayerPlay())
                {
                    this.statusLabel.Text = "Cannot draw now. You have at least one card you can play.";
                }
                else
                {
                    // Add it to player's hand and update GUI
                    // Try catch to the player's pile
                    try
                    {
                        this.PlayerHand.Add(this.Cardpile.DealCards(1)[0]);
                        DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);
                    }
                    catch
                    {
                        // New card pile
                        this.NewPlayingCardPile();
                        this.PlayerHand.Add(this.Cardpile.DealCards(1)[0]);
                        DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);
                    }

                    if (this.CanPlayerPlay())
                    {
                        this.statusLabel.Text = "Your turn. Click on one of your cards to play.";
                    }
                    else
                    {
                        this.statusLabel.Text = "You have no cards that you can play. You must draw a card.";
                    }
                }
            }
        }

        // New card pile
        // While playing
        private void NewPlayingCardPile()
        {
            // New card pile
            this.Cardpile = new CardPile(false);
            this.Cardpile.Shuffle();

            // Add all cards in pile hand
            for (int i = 0; i < PileHand.GetCount()-1; i++)
            {
                this.Cardpile.Add(PileHand.GetCard(i));
            }
        }

        // Prevent form from closing
        private void Crazy_Eight_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Pop up message box
            DialogResult rslt = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user wants to quit
            if (rslt == DialogResult.Yes)
            {                
                this.Close();
            }
        }

        // Can Player play
        private bool CanPlayerPlay()
        {
            if (AnySuit)
            {
                return true;
            }

            // If player has a playable card, then play on
            foreach (Card c in this.PlayerHand)
            {
                if ((!UseCustomSuitValue && c.GetSuit() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetSuit()) ||
                    (UseCustomSuitValue && c.GetSuit() == this.CustomSuitValue) ||
                    c.GetFaceValue() == PileHand.GetCard(this.PileHand.GetCount() -1).GetFaceValue() || 
                    c.GetFaceValue() == FaceValue.Eight)
                {                    
                    return true;
                }
            }
            return false;
        }

        // Can computer play
        private bool CanComputerPlay()
        {
            // If player has a playable card, then play on
            foreach (Card c in this.ComputerHand)
            {
                if ((!UseCustomSuitValue && c.GetSuit() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetSuit()) ||
                    (UseCustomSuitValue && c.GetSuit() == this.CustomSuitValue) ||
                    c.GetFaceValue() == PileHand.GetCard(this.PileHand.GetCount() - 1).GetFaceValue() ||
                    c.GetFaceValue() == FaceValue.Eight)
                {
                    return true;
                }
            }
            return false;
        }

        // Can't focus if suit form is visible
        private void statusLabel_Enter(object sender, EventArgs e)
        {
            if (!this.chooseSuitForm.Visible)
            {
                this.chooseSuitForm.Focus();
            }
        }
    }
}
