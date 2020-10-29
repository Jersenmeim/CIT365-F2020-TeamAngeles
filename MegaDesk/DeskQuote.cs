using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MegaDesk_Meim
{
    class DeskQuote
    {
        private Desk desk;
        private int size;
        private int oversize;
        private double oversizeCost, materialCost, drawerCost, rushOrderCost, totalCost;
        public int Oversize { get { return oversize; } set { oversize = value; } }
        public double OversizeCost { get { return oversizeCost; } set { oversizeCost = value; } }
        public double MaterialCost { get { return materialCost; } set { materialCost = value; } }
        public double DrawerCost { get { return drawerCost; } set { drawerCost = value; } }
        public double RushOrderCost { get { return rushOrderCost; } set { rushOrderCost = value; } }
        public double TotalCost { get { return totalCost; } set { totalCost = value; } }
        public int Size { get { return size; } set { size = value; } }
        public DeskQuote(Desk desk)
        {
            this.desk = desk;
        }



        //Calculation for oversize cost
        public void CalcOversizeCost()
        {
            int width = desk.Width;
            int depth = desk.Depth;
            size = width * depth;
            // returns the value of its left-hand operand if it isn't null
            oversize = size > 1000 ? size - 1000 : 0;
            if (oversize > 0)
                oversizeCost = oversize;
        }

        //Prices for each material and theri calculation
        public void CalcMtrlCost(string material)
        {
            switch (material)
            {
                case "Laminate":
                    materialCost = (int)Material.Laminate;
                    break;
                case "Oak":
                    materialCost = (int)Material.Oak;
                    break;
                case "Pine":
                    materialCost = (int)Material.Pine;
                    break;
                case "Rosewood":
                    materialCost = (int)Material.Rosewood;
                    break;
                case "Veneer":
                    materialCost = (int)Material.Veneer;
                    break;
                default: //error or empty
                    materialCost = 0;
                    break;
            }

        }

        //Cost per drawer
        public void CalcDrawerCost()
        {
            drawerCost = desk.NumDrawers * 50;
        }

       


        //Rush order Calculation and readfile: rushOrderPrices.txt
        public void CalcRushOrderCost(string rushOrderDays)
        {


            var lines = File.ReadAllLines("../../../rushOrderPrices.txt");
            for (int i = 0; i < lines.Length; i++)
                //MessageBox.Show(lines[i]);


            if (size < 1000)
            {
                if (rushOrderDays.Equals("3 Days"))
                    rushOrderCost = Convert.ToInt32(lines[0]);//60
                else if (rushOrderDays.Equals("5 Days"))
                    rushOrderCost = Convert.ToInt32(lines[3]);//40
                else if (rushOrderDays.Equals("7 Days"))
                    rushOrderCost = Convert.ToInt32(lines[6]);//30
                else
                    rushOrderCost = 0;
            }
            else if (size >= 1000 || size <= 2000)
            {
                if (rushOrderDays.Equals("3 Days"))
                    rushOrderCost = Convert.ToInt32(lines[1]);//70
                else if (rushOrderDays.Equals("5 Days"))
                    rushOrderCost = Convert.ToInt32(lines[4]);//50
                else if (rushOrderDays.Equals("7 Days"))
                    rushOrderCost = Convert.ToInt32(lines[7]);//35
                else
                    rushOrderCost = 0;
            }
            else //(size > 2000) //need to check
            {
                if (rushOrderDays.Equals("3 Days"))
                    rushOrderCost = Convert.ToInt32(lines[2]);//80
                else if (rushOrderDays.Equals("5 Days"))
                    rushOrderCost = Convert.ToInt32(lines[0]);//60
                else if (rushOrderDays.Equals("7 Days"))
                    rushOrderCost = Convert.ToInt32(lines[8]);//40
                else
                    rushOrderCost = 0;
            }

        }

        //Total Cost Calculation
        public void CalcTotalCost()
        {
            totalCost = oversizeCost + materialCost + drawerCost + rushOrderCost + 200;
        }
    }
}

