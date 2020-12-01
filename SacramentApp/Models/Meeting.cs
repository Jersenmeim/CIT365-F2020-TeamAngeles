using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SacramentApp.Models
{
    public class Meeting
    {
   
        public int Id { get; set; }


        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }



        [StringLength(100, MinimumLength = 5)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Letters only the and first letter should be Uppercase")]
        [Display(Name = "Conducting Leader")]
        public string ConductingLeader { get; set; }



        [StringLength(100, MinimumLength = 1)]
        [Required]
        [Display(Name = "Opening Hymn")]
        public string OpeningHymn { get; set; }



        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Letters only the first letter should be Uppercase")]
        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Invocation { get; set; }



        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Sacrament Hymn")]
        [Required]
        public string SacramentHymn { get; set; }



        [StringLength(100)]
        [Display(Name = "Intermediate Hymn")]
        public string IntermediateHymn { get; set; }



        [StringLength(100, MinimumLength = 1)]
        [Required]
        [Display(Name = "Closing Hymn")]
        public string ClosingHymn { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Letters only and the first letter should be Uppercase")]
        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string Benediction { get; set; }

        public ICollection<Talks> Talks { get; set; }
    }
}

