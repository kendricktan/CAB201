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
    public partial class Which_Card_Game : Form
    {
        Twenty_One TwentyOneForm = new Twenty_One();
        Crazy_Eight CrazyEightForm = new Crazy_Eight();

        public Which_Card_Game()
        {
            InitializeComponent();
        }

        private void Which_Card_Game_FormClosing(object sender, FormClosingEventArgs e)
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
                this.Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
            {
                this.TwentyOneForm.Show();
            }

            if (this.comboBox1.SelectedIndex == 1)
            {
                this.CrazyEightForm.Show();
            }
        }
    }
}
