using Microsoft.AspNetCore.Mvc;
using SistemaGestionWebApi.Models;

namespace SistemaGestionWebApi.Controllers
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

   

        [HttpGet("rutaNueva")]
        public string ObtenerSaludo()
        {
            return "Hola mundo desde API";
        }

        [HttpGet("{rutaNueva}")]
        public string ObtenerSaludo(string parametro)
        {
            return "PARAMETRO"+parametro;
        }
    }

    





}