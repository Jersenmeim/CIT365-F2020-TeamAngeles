using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskWebApp.Models
{
    public class DeskQuote
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 2),  Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 2), Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Range(MIN_WIDTH, maximum: MAX_WIDTH)]
        public int Width { get; set; }

        [Range(MIN_DEPTH, maximum: MAX_DEPTH)]
        public int Depth { get; set; }

        [Range(0, MAX_DRAWERS), Display(Name = "No of Drawer")]
        public int NumberOfDrawers { get; set; }


        [Display(Name = "Material")]
        [Required]
        public DesktopMaterial DesktopMaterial { get; set; }


        [Display(Name = "Quote Date")]
        [DataType(DataType.Date)]     
        public DateTime QuoteDate { get; set; }

        [Range(0, 7)]
        [Display(Name = "Rush Order Option")]
        public int RushDays { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }



        [Display(Name = "Surface Area")]
        public int SurfaceArea
        {
            get
            {
                return Width * Depth;
            }
        }
        [Display(Name = "Quote Price")]
        public int QuoteAmount
        {
            get
            {
                return CalculateQuotePrice();
            }
        }
        [Display(Name = "Base Price")]
        public int BasePrice
        {
            get
            {
                return SurfaceAreaCost();
            }
        }

        [Display(Name = "Rush Cost")]
        public int RushCost
        {
            get
            {
                return RushFee();
            }
        }


        public int MaterialFee
        {
            get
            {
                return (int)DesktopMaterial;
            }
        }

        public const int MAX_WIDTH = 96;
        public const int MIN_WIDTH = 24;
        public const int MIN_DEPTH = 12;
        public const int MAX_DEPTH = 48;
        private const int PRICE_BASE = 200;
        public const int PRICE_DRAWER = 50;
        private const int PRICE_SQ_FOOT = 1;
        private const int BASE_SIZE = 1000;
        private const int UPPER_SIZE = 2000;
        public const int MAX_DRAWERS = 7;
        private readonly int[,] RUSHFEES = new int[3, 3]
            {
                { 60, 70, 80 },
                { 40, 50, 60 },
                { 30, 35, 40 }
            };
        // Calculation
        public int CalculateQuotePrice()
        {
            int quotePrice = SurfaceAreaCost() + DrawerCost() + (int)DesktopMaterial + RushFee();
            return quotePrice;
        }
        public int SurfaceAreaCost()
        {
            if (SurfaceArea > BASE_SIZE)
            {
                int surfaceCost = (SurfaceArea - BASE_SIZE) * PRICE_SQ_FOOT;
                return surfaceCost + PRICE_BASE;
            }
            else
            {
                return PRICE_BASE;
            }
        }
        public int DrawerCost()
        {
            int drawerPrice = NumberOfDrawers * PRICE_DRAWER;
            return drawerPrice;
        }

        // calculate rush fee based on surface area and Rush
        public int RushFee()
        {
            
            int sizeIndex = 0;
            int rush = 0;
            if (SurfaceArea < BASE_SIZE)
            {
                sizeIndex = 0;
            }
            else if (SurfaceArea <= UPPER_SIZE)
            {
                sizeIndex = 1;
            }
            else
            {
                sizeIndex = 2;
            }
            // return rush fee based on sizeIndex and Rush
            if (RushDays == 3)
            {
                rush = RUSHFEES[0, sizeIndex];

            }
            else if (RushDays == 5)
            {
                rush = RUSHFEES[1, sizeIndex];
            }
            else if (RushDays == 7)
            {
                rush = RUSHFEES[2, sizeIndex];
            }
            else
            {
                rush = 0;
            }
            return rush;
        }
    }
}

    //enum
    public enum DesktopMaterial
    {
        Oak = 200,
        Laminate = 100,
        Pine = 50,
        Rosewood = 300,
        Veneer = 125
    };

