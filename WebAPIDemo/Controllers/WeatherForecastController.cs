using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private NameService NameService { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, NameService nameService) //this needs to be registered in Program.cs
        {
            _logger = logger;
            NameService = nameService;
            //don't use this add dependency injection instead. See above after "logger,"
            //NameService = new NameService();
            NameService = nameService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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
        [HttpPost(Name = "PostWeatherForecast")]
        public async Task<IActionResult> Post()
        {
            //post logic
            return Ok("Weatherforecast posted.");
        }

        [HttpPut(Name = "PutWeatherForecast")]
        public async Task<IActionResult> Put(WeatherForecast weatherForecast)
        {
            //put logic
            return Ok("Weatherforecast updated.");
        }

        [HttpDelete(Name = "DeleteWeatherForecast")]
        public async Task<IActionResult> Delete(int id)
        {
            //delete logic
            return Ok("Weatherforecast deleted.");
        }
    }
}
