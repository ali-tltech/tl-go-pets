using Microsoft.AspNetCore.Mvc;
using TLgopetz.Services;
using System;
using System.Threading.Tasks;
using TLCAREERSCORE.Models;

namespace TLgopetz.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnsubscriberController : ControllerBase
    {
        private readonly IUnsubscribe _unsubscribeService;

        public UnsubscriberController(IUnsubscribe unsubscribeService)
        {
            _unsubscribeService = unsubscribeService;
        }

        [HttpPost("{email}")]
        public IActionResult Post(string email)
        {
            try
            {
                // Create an instance of unsubcribemodel and assign the email
                var unsubcribemodel = new unsubcribemodel { email = email };

                // Call the UnsubscribeApplication method from the unsubscribe service
                _unsubscribeService.UnsubscribeApplication(unsubcribemodel);

                // Return a successful response
                return Ok("Unsubscribed successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the unsubscribe process
                // You can display an error message or return an appropriate status code
                return StatusCode(500, $"Failed to unsubscribe: {ex.Message}");
            }
        }

    }
}
