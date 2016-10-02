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
    public partial class Which_Dice_Game : Form
    {
        Snake_Eyes SnakeEyesForm = new Snake_Eyes();
        Ship_Captain_Crew ShipCaptainCrewForm = new Ship_Captain_Crew();

        public Which_Dice_Game()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                SnakeEyesForm.Show();
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                ShipCaptainCrewForm.Show();
            }
        }

        private void Which_Dice_Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // Pop up message box
            DialogResult rslt = MessageBox.Show("Do you really want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user wants to quit
            if (rslt == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
