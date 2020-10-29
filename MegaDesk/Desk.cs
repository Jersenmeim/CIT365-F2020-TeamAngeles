using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MegaDesk_Meim
{
    //list of material using enum method
    public enum Material
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    };
    //Getter and Setter for width, depth and number of drawers

    public class data
    {
        public string Name { get; set; }
        public string widths { get; set; }
        public string depths { get; set; }
        public string drawers { get; set; }
        public string materials { get; set; }
        public string rush { get; set; }
        public string total { get; set; }

        public string date { get; set; }

    }


    public class Desk
    {


        public string Name { get; set; }
        public string materials { get; set; }
        public string rush { get; set; }
        public string total { get; set; }

        public string date { get; set; }

        private int width, depth, numDrawers;
        public int Width { get { return width; } set { width = value; } }
        public int Depth { get { return depth; } set { depth = value; } }
        public int NumDrawers { get { return numDrawers; } set { numDrawers = value; } 
        
        }
       
        public Desk(int w, int d, int nd)
        {
            Width = w;
            Depth = d;
            NumDrawers = nd;
        }

       


        //4 constraints
        public const int MINWIDTH = 24;
        public const int MAXWIDTH = 96;
        public const int MINDEPTH = 12;
        public const int MAXDEPTH = 48;

        public static void ToList()
        {
            // adding elements using add() method
            var DesktopMaterial = new List<String>();
            DesktopMaterial.Add("Oak");
            DesktopMaterial.Add("Laminate");
            DesktopMaterial.Add("Pine");
            DesktopMaterial.Add("Rosewood");
            DesktopMaterial.Add("Veneer");

        } 
    }
}
