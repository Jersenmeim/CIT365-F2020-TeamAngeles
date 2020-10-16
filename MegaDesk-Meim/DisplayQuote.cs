using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;


namespace MegaDesk_Meim
{
    public partial class DisplayQuote : Form
    {
       public static string TotalValue;
       public static string OversizeValue;
       public static string RushCostValue;
       public static string MaterialCost;
       public static string DrawerCostValue;

        //Passing the total cost value from AddQuote to this form
        public DisplayQuote()
        {
            InitializeComponent();
        }

        //Passing of all other values from AddQuote to DisplayQuote
        public void DisplayQuote_Load(object sender, EventArgs e)
        {
            
            name.Text = AddQuote.NameValue;
            date.Text = AddQuote.DateToday;
            width.Text = AddQuote.WidthValue + " inch";
            depth.Text = AddQuote.DepthValue + " inch";
            drawer.Text = AddQuote.NoOfDrawer;
            material.Text = AddQuote.MaterialUsed;
            rush.Text = AddQuote.RushOption;
            label1.Text = TotalValue;
            label14.Text = OversizeValue;
            label9.Text = RushCostValue;
            label11.Text = MaterialCost;
            label12.Text = DrawerCostValue;
        }

        private void date_Click(object sender, EventArgs e)
        {
        }
        private void back_Click_1(object sender, EventArgs e)
        {
            AddQuote addNewQuoteForm = new AddQuote();
            addNewQuoteForm.Show(this);
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddQuote ne = new AddQuote();
            ne.MaterialField.SelectedIndex = -1;
            ne.MaterialField.DataSource = Enum.GetValues(typeof(Material));
            WriteFile();
        }
        //Writefile to quotes.json
        private void WriteFile()
        {
            data desk = new data();
            try
            {
               
                desk.Name = name.Text;
                desk.widths = Convert.ToString( width.Text);
                desk.depths = Convert.ToString(depth.Text);
                desk.drawers = Convert.ToString(drawer.Text);
                desk.materials = material.Text;
                desk.rush = rush.Text;
                desk.total = label1.Text;
                desk.date = DateTime.Now.ToString("MM/dd/yyyy");

              
                //Adding to JSON
                var Json = File.ReadAllText("../../../quotes.json");
                List<data> Add = new List<data>() { desk };

                string update = AddObject(Json, Add);

                File.WriteAllText("../../../quotes.json", update);

                MessageBox.Show("Quote has been created!");    
                    AddQuote ne = new AddQuote();
                    ne.MaterialField.SelectedIndex = -1;
                    ne.Drawer.SelectedIndex = -1;
                    ne.RushOrderOption.SelectedIndex = -1;
                  
                    AddQuote addNewQuoteForm = new AddQuote();
                    addNewQuoteForm.Show(this);
                    addNewQuoteForm.NameField.Clear();
                    Hide();
            }
            catch (Exception)
            {
               // Console.WriteLine("Error when try to use StreamWriter. It says : " + e.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }
        //Adding to JSON
        private string AddObject<T>(string json, List<T> objects)
        {
            List<T> list = JsonConvert.DeserializeObject<List<T>>(json);
            list.AddRange(objects);
            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }
    }
}
