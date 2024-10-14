using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOptions _options;

        public HomeController(IOptions<WeatherApiOptions> options)
        {
            _options = options.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //Method 1
            //ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            //ViewBag.ClientSecret = _configuration["weatherapi:ClientSecret"];

            //Method 2
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();
            //ViewBag.ClientID = options.ClientID;
            //ViewBag.ClientSecret = options.ClientSecret;


            //Method 3
            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;

            return View();
        }
    }
}
