using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;



namespace MegaDesk_Meim
{
    public partial class AddQuote : Form
    {
        // Make the variables accecible to all forms
        public static string NameValue;
        public static double WidthValue;
        public static double DepthValue;
        public static string MaterialUsed;
        public static string NoOfDrawer;
        public static string RushOption;
        public static string DateToday;
        public static string total;

        public AddQuote()
        {
            InitializeComponent();
        }

        private void AddQuote_Load(object sender, EventArgs e)
        {
            Drawer.SelectedItem = "0";
            MaterialField.SelectedItem = "Oak";
            RushOrderOption.SelectedItem = "Normal";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        //Back Button
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MainMenu main = new MainMenu();
                main.Show(this);
                Hide();
            }
            catch (Exception)
            {
                Hide();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        //Storing Values to a variable
        private void button2_Click(object sender, EventArgs e)
        {

            //Use try catch block to handle exception; empty text box.
            try
            {

                {
                    NameValue = NameField.Text; //save name-data in variable
                    WidthValue = double.Parse(WidthField.Text); //save width-data in variable
                    DepthValue = double.Parse(DepthField.Text); //save depth-data in variable
                    DateToday = DateTime.Now.Date.ToLongDateString().Replace(DateTime.Now.DayOfWeek.ToString() + ", ", "");
                    NoOfDrawer = Drawer.Text; //Display Drawers in Panel
                    MaterialUsed = MaterialField.Text; //Display Material in Panel
                    RushOption = RushOrderOption.Text; //Display Rush Order in Panel

                    //Calling the GetPrice Method
                    GetPrice();
                    Close();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Could not confirm quote details. Please fill out all fields", "Error");
                //throw;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //Validate Customer's Name
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (NameField.Text == String.Empty)
            {
                //MessageBox.Show("Please enter a Name");
                NameField.Text = String.Empty;
                NameField.BackColor = Color.Red;
            }
            else
            {
                NameField.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        //Validate Width Values using Constraint
        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(WidthField.Text, out int WidthInput) == true)
            {
                if (WidthInput < Desk.MINWIDTH || WidthInput > Desk.MAXWIDTH)
                {
                    MessageBox.Show("Please enter a width from " + Desk.MINWIDTH + " to " + Desk.MAXWIDTH + " inches");
                    WidthField.Text = String.Empty;
                    WidthField.BackColor = Color.Red;
                    WidthField.Focus();
                }
                else
                {
                    WidthField.BackColor = System.Drawing.SystemColors.Window;
                }
            }
            else if (int.TryParse(WidthField.Text, out WidthInput) == false && WidthField.Text.Length != 0)
            {
                MessageBox.Show("Please enter a number");
                WidthField.Text = String.Empty;
                WidthField.BackColor = Color.Red;
                WidthField.Focus();
            }
            else
            {
                WidthField.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        //Validate Depth Values using Constraint

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(DepthField.Text, out int DepthInput) == true)
            {
                if (DepthInput < Desk.MINDEPTH || DepthInput > Desk.MAXDEPTH)
                {
                    MessageBox.Show("Please enter a depth from " + Desk.MINDEPTH + " to " + Desk.MAXDEPTH + " inches");
                    DepthField.Text = String.Empty;
                    DepthField.BackColor = Color.Red;
                    DepthField.Focus();
                }
                else
                {
                    DepthField.BackColor = System.Drawing.SystemColors.Window;
                }
            }
        }

        //Validate Depth Values using Keypress
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false)
            {
                MessageBox.Show("Please enter a number");
                e.Handled = true;
                DepthField.BackColor = Color.Red;
                DepthField.Focus();
            }
            else
            {
                DepthField.BackColor = System.Drawing.SystemColors.Window;
            }
        }

        private void GetPrice()
        {

            int width = int.Parse(WidthField.Text);
            int depth = int.Parse(DepthField.Text);
            int size = width * depth;

            //Pass all values to the parameter

            int.TryParse(Drawer.Text, out int nDrawers);

            Desk desk = new Desk(int.Parse(WidthField.Text), int.Parse(DepthField.Text), nDrawers);
            DeskQuote DeskQuotes = new DeskQuote(desk);

            DeskQuotes.CalcOversizeCost();
            DeskQuotes.CalcDrawerCost();
            DeskQuotes.CalcMtrlCost(MaterialField.Text);
            DeskQuotes.CalcRushOrderCost(RushOrderOption.Text);
            DeskQuotes.CalcTotalCost();

            //Display the quote togehter with the calculation
            DisplayQuote DisplayQuote = new DisplayQuote();
            DisplayQuote.RushCostValue = "$" + DeskQuotes.RushOrderCost;
            DisplayQuote.OversizeValue = "$" + DeskQuotes.OversizeCost;
            DisplayQuote.DrawerCostValue = "$" + DeskQuotes.DrawerCost;
            DisplayQuote.MaterialCost = "$" + DeskQuotes.MaterialCost;
            DisplayQuote.TotalValue = "$" + DeskQuotes.TotalCost;

            DisplayQuote.Show();
        }

        private void Drawer_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
