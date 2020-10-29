using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace MegaDesk_Meim
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        //event that return to main menu
        private void button1_Click(object sender, EventArgs e)
        {
            ReadFile();
        }

        //Readfile from quotes.json
        private void ReadFile()
        {
            ///Read a json file.
            StreamReader read = new StreamReader("../../../quotes.json");

            
            string Json = read.ReadToEnd();
            string materialsearch = srcbox.SelectedItem.ToString();

            // clear the data in grid
            dataGridView1.Rows.Clear();
            //Using JSON.NET convert the data stored in the string into a list of Desk objects.
            List<data> desks = JsonConvert.DeserializeObject<List<data>>(Json);

            //Loop through the list of desks. 
            foreach (data desk in desks)
            {
                if (desk.materials.ToString() == materialsearch)
                {
                    string[] row = {desk.Name, desk.widths, desk.depths, desk.drawers, desk.materials, desk.rush, 
                        desk.total.ToString(), desk.date};
                    //adding each item to row
                    dataGridView1.Rows.Add(row);
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
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

        private void SearchQuotes_Load(object sender, EventArgs e)
        {
         
        }
    }
}
