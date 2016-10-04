﻿using System;
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

        public Twenty_One()
        {
            InitializeComponent();

            Cardpile = new CardPile(true);
            Cardpile.Shuffle();            
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
            const int testNumOfCardsForDealer = 2;
            const int testNumOfCardsForPlayer = 8;

            CardPile testCardPile = new CardPile(true);
            testCardPile.Shuffle();

            Hand testHandForDealer = new Hand(testCardPile.DealCards(testNumOfCardsForDealer));
            Hand testHandForPlayer = new Hand(testCardPile.DealCards(testNumOfCardsForPlayer));

            DisplayGuiHand(testHandForDealer, dealerTableLayoutPanel);
            DisplayGuiHand(testHandForPlayer, playerTableLayoutPanel);
        }


        // Deals them cards
        private void dealButton_Click(object sender, EventArgs e)
        {
            PlayerHand = new Hand(Cardpile.DealCards(2));
            DealerHand = new Hand(Cardpile.DealCards(2));

            DisplayGuiHand(PlayerHand, playerTableLayoutPanel);
            DisplayGuiHand(DealerHand, dealerTableLayoutPanel);
        }
    }
}
