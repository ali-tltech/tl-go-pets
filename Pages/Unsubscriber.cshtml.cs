using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace TLgopetz.Pages
{
    public class UnsubscriberModel : PageModel


    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string _url;

        public UnsubscriberModel(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _url = configuration.GetConnectionString("url");

        }

        public async Task<IActionResult> OnGet(string email)
        {
            var apiUrl = _url + email;

            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var response = await httpClient.PostAsync(apiUrl, null);
                if (response.IsSuccessStatusCode)
                {
                    // Unsubscription successful
                    return Page();
                }
                else
                {
                    // Failed to unsubscribe, handle the error
                    return Content("Failed to unsubscribe: " + response.StatusCode);
                }
            }
        }
    }
}
