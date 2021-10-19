using Microsoft.AspNetCore.Mvc;

namespace NotesAPI
{
    [ApiController]
    [Route( "[controller]")]
    public class WeatherForecastController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok("Weather is dry");
        }
    }
}