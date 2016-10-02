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
    }
}
