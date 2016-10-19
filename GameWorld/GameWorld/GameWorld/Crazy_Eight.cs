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
        private CardPile Cardpile;
        private Hand PileHand;
        private Hand PlayerHand;
        private Hand ComputerHand;        

        public Crazy_Eight()
        {
            InitializeComponent();

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
        }

        private void TryToPlayCard(Card clickedCard)
        {
            // Can play if card values are the same
            if (clickedCard.GetFaceValue() == this.PileHand.GetCard(this.PileHand.GetCount() - 1).GetFaceValue()
                || clickedCard.GetSuit() == this.PileHand.GetCard(this.PileHand.GetCount() - 1).GetSuit())
            {
                this.PlayerHand.Remove(clickedCard);
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

            this.PlayerHand = new Hand(this.Cardpile.DealCards(5));
            this.ComputerHand = new Hand(this.Cardpile.DealCards(5));
            this.PileHand = new Hand(this.Cardpile.DealCards(1));

            DisplayGuiHand(this.ComputerHand, this.tableLayoutPanel1, 1);
            DisplayGuiHand(this.PlayerHand, this.tableLayoutPanel2, 2);

            // Get last iamge 
            this.pileHandPictureBox.Image = Images.GetCardImage(this.PileHand.GetCard(this.PileHand.GetCount() - 1));

            this.dealButton.Enabled = false;
        }
    }
}
