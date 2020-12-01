using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SacramentApp.Models
{
    public class Talks
    {
  
        public int Id { get; set; }
        public int MeetingId { get; set; }
        [Display(Name = "Name of Speaker")]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Letters only the and first letter should be Uppercase")]
        [StringLength(100, MinimumLength = 5)]
        public string NameSpeaker { get; set; }




        [StringLength(100, MinimumLength = 5)]
        [Required]
        [Display(Name = "Topic")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "Letters only the and first letter should be Uppercase")]
        public string Topic { get; set; }
    }
}
