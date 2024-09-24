using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCAREERSCORE.Models;
using TLCAREERSCORE.Services;

namespace TLCAREERSCORE.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassifiedController : ControllerBase
    {
        private readonly IClassified _Classified;

        public ClassifiedController(IClassified Classifieds)//constructor
        {
            _Classified = Classifieds;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_Classified.GetClassifiedList("admin"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
