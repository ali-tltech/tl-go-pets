using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TLCAREERSCORE.Models;
using TLCAREERSCORE.Services;

namespace TLCAREERSCORE.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IPosition _Position;

        public PositionController(IPosition Positions)//constructor
        {
            _Position = Positions;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_Position.GetPositionList("admin"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("searchPosition")]
        public IActionResult SearchPosition(string position)
        {
            try
            {
                return Ok(_Position.GetSearchPosition(position));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
