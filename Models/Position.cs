using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TLCAREERSCORE.Models
{
    public class Position : BaseEntity
    {
        public string? PositionID { get; set; } 

        [Display(Name = "Position Title", Prompt = "Position Title")]
        [Required(ErrorMessage = "Position Title Code is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only please")]
        public string PositionTitle { get; set; }

        [Display(Name = "Position Description", Prompt = "Position Description")]
        [Required(ErrorMessage = "Position Description is required")]
        public string PositionDescription { get; set; }
       
        [Display(Name = "Number of Positions", Prompt = "Number of Positions")]
        [Required(ErrorMessage = "Number of Positions is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        [MaxLength(2)]
        public string Flexfld2 { get; set; }
        public string? WorkLocation { get; set; }

        [Display(Name = "Salary", Prompt = "Salary")]
        [Required(ErrorMessage = "Salary is required")]
        public string? Salary { get; set; }

    }
}
