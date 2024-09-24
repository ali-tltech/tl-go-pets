using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TLCAREERSCORE.Models
{
    public class Classified : BaseEntity
    {
        public string? ClassifiedID { get; set; }

        [Display(Name = "Classified Title", Prompt = "Classified Title")]
        [Required(ErrorMessage = "Classified Title is required")]
        public string? ClassifiedTitle { get; set; }

        [Display(Name = "Classified Description", Prompt = "Classified Description")]
        [Required(ErrorMessage = "Classified Description is required")]
        public string? ClassifiedDescription { get; set; }

        [Display(Name = "Classified Image", Prompt = "Classified Image")]
        public string? ClassifiedImage { get; set; }

        [Display(Name = "Classified By", Prompt = "Classified By")]
        public string? ClassifiedBy { get; set; }


    }
}
