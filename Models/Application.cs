using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TLCAREERSCORE.Models
{
    public class Application : BaseEntity
    {
      
        public string email { get; set; }
       
        //public string? AttachmentPath { get; set; }

       // public IFormFile resumepdf { get; set; }

    }
}
