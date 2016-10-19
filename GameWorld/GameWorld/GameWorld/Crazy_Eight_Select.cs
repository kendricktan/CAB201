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
    public partial class ChooseSuitForm : Form
    {
        private Crazy_Eight crazy_eight;

        public ChooseSuitForm(Crazy_Eight form)
        {
            InitializeComponent();
            this.crazy_eight = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.GetSuitValue();
            this.crazy_eight.ComputerPlay();

            this.Visible = false;
        }

        private void ChooseSuitForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            e.Cancel = true;
            this.Visible = false;
        }

        public void GetSuitValue()
        {
            if (this.ClubsRadioButton.Checked)
            {
                this.crazy_eight.CustomSuitValue = Suit.Clubs;
                return;
            }
            if (this.DiamondsRadioButton.Checked) {
                this.crazy_eight.CustomSuitValue = Suit.Diamonds;
                return;
            }
            if (this.HeartsRadioButton.Checked)
            {
                this.crazy_eight.CustomSuitValue = Suit.Hearts;
                return;
            }
            this.crazy_eight.CustomSuitValue = Suit.Spades;
            return;
        }
    }
}
