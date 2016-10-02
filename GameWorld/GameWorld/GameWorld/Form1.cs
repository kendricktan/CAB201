using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWorld
{
    public partial class MainForm : Form
    {
        // Our other forms
        Form CoinForm = new Two_Up();
        Form DiceGamesForm = new Which_Dice_Game();
        Form CardGamesForm = new Which_Card_Game();

        public MainForm()
        {
            InitializeComponent();

            // Don't want any radio button checked
            this.CoinRadioButton.Checked = false;
            this.CardRadioButton.Checked = false;
            this.DiceRadioButton.Checked = false;

            // Disable enable button
            this.StartButton.Enabled = false;
        }

        // User wants to quit
        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Pop up message box
            DialogResult rslt = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user wants to quit
            if (rslt == DialogResult.Yes)
            {
                CoinForm.Close();
                DiceGamesForm.Close();
                CardGamesForm.Close();
                this.Close();
            }            
        }

        // Generic checked changed for radio buttons
        private void GenericRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.StartButton.Enabled = true;
        }

        // Check start button
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (this.CoinRadioButton.Checked)
            {
                this.CoinForm.Show();
            }

            if (this.DiceRadioButton.Checked)
            {
                this.DiceGamesForm.Show();
            }

            if (this.CardRadioButton.Checked)
            {
                this.CardGamesForm.Show();
            }
        }
    }
}
