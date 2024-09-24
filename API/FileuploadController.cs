
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MimeKit;
using TLCAREERSCORE.Services;

    namespace TLCAREERSCORE.API
    {
        public class FileuploadController : Controller
        {
        private static int saveCount = 0;

        [Route("api/[controller]")]
            [HttpPost("SavePDF")]
            public IActionResult SavePDF(IFormFile file, string email, string phoneNumber)
        {
            string currentDateAndTime = DateTime.Now.ToString("yyyyMMddHHmm");
            saveCount++;
            string uniqueNumber = saveCount.ToString("D3");
            try
                {
                    if (file == null || file.Length == 0)
                    {
                        return BadRequest("No file was uploaded.");
                    }
               // string currentDateAndTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                // Generate a unique file name
                string uniqueFileName = currentDateAndTime+ uniqueNumber+ Path.GetExtension(file.FileName);

                    // Set the file path where the PDF will be saved
                    string filePath = Path.Combine("resumepdf", uniqueFileName);

                // Check if the file already exists
                if (System.IO.File.Exists(filePath))
                {
                    // Delete the existing file
                    System.IO.File.Delete(filePath);
                }

                // Save the PDF file to the specified path
                using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
               

                    return Ok(new { fileName = uniqueFileName });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred while saving the PDF file: {ex.Message}");
                }
            }

          
        }
    }


