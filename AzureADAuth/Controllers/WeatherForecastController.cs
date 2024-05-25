using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AzureADAuth.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> LogIn()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=5003cdd0-1bab-4dae-bdf2-89439c598356&response_type=code&redirect_uri=https%3A%2F%2Flocalhost%3A7075&response_mode=query&scope=api://5003cdd0-1bab-4dae-bdf2-89439c598356/admin.user&state=12345&nonce=678901");

            string htmlContent = await response.Content.ReadAsStringAsync();

            // Check if the request was successful (status code in the range 200-299)
            if (response.IsSuccessStatusCode)
            {
                // Return the HTML content to the client
                return Content(htmlContent, "text/html");
            }
            else
            {
                // Return an error response with the status code
                return StatusCode((int)response.StatusCode);
            }
        }


        [Authorize]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
