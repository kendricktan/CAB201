using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class Form1 : Form
    {
        // Private variables fam
        private double basePrice = 10.00;
        private double additionalBasePrice = 0.00;
        private int additionalToppings = 0;
        private string baseType = "", sauceType = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // RadioButton event handlers
            thinRBtn.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
            thickRBtn.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
            GFRBtn.CheckedChanged += new EventHandler(RadioButtonsCheckedChanged);
        }

        // Event handle for all radio buttons
        private void RadioButtonsCheckedChanged(object sender, EventArgs e)
        {
            // Can't uncheck radio button                        
            this.sauceComboBox.Enabled = true;

            // Get type of crust
            RadioButton r = (RadioButton)sender;
            baseType = r.Text.ToLower();

            if (GFRBtn.Checked)
            {
                additionalBasePrice = 2.00;
            }
            else
            {
                additionalBasePrice = 0.00;
            }
        }

        // Sets the state for the controls 
        // e.g. radio buttons, checkboxes, comboboxes
        private void SetControlsState(bool b)
        {
            // Our combobox
            // Combobox is enabled by selecting a radiobutton
            //this.sauceComboBox.Enabled = b;

            // Toppings group box
            foreach (Control c in this.toppingsGroupBox.Controls)
            {
                if (c is CheckBox || c is ComboBox || c is RadioButton)
                {
                    c.Enabled = b;
                }
            }

            // Crust groupbox
            foreach (Control c in this.crustGroupBox.Controls)
            {
                if (c is CheckBox || c is ComboBox || c is RadioButton)
                {
                    c.Enabled = b;
                }
            }
        }

        // User enters their name into this textbox
        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.nameTextBox.Text != "")
            {
                this.SetControlsState(true);
            }
            else
            {
                this.SetControlsState(false);
            }
        }

        // Checkbox event handler
        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            this.doneBtn.Visible = true;

            CheckBox c = (CheckBox)sender;
            if (c.Checked)
            {
                additionalToppings += 1;
            }
            else
            {
                additionalToppings -= 1;
            }
        }

        // Combooooo breaker
        // What kinda sauce fam
        private void sauceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sauceType = sauceComboBox.SelectedItem.ToString().ToLower();
        }

        // Get total price
        private double getTotalPrice()
        {
            double totalPrice = basePrice + additionalBasePrice;
            if (additionalToppings - 4 > 0)
            {
                totalPrice += (additionalToppings - 4);
            }
            return totalPrice;
        }

        // Button event handler fam
        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (baseType == "")
            {
                MessageBox.Show("You haven't selected a pizza crust yet!");
                return;
            }

            if (sauceType == "")
            {
                MessageBox.Show("You haven't selected a sauce type yet!");
                return;
            }

            // No toppings
            if (additionalToppings == 0)
            {
                MessageBox.Show("You require at least 1 topping to complete your order. \n\nRemember up to 4 toppings are free!");
            }

            // >0 toppings
            else
            {
                
                                                                                                
                MessageBox.Show("Thank you for your order " + this.nameTextBox.Text + "\n of a " + this.baseType + " base with " + this.sauceType + " sauce and " + additionalToppings.ToString() + " toppings.\n\nThe cost of your pizza is $" + getTotalPrice().ToString("F"));
                MessageBox.Show("Thanks for ordering from Beagle Boy Pizza,\nyour pizza will be delivered in 30 minutes or its free!");
            }
        }
    }
}
