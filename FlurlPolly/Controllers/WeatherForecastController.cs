using Flurl.Http;
using FlurlPolly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FlurlPolly.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                var carromodel = "https://localhost:5002/weatherforecast".GetJsonAsync<WeatherForecast>();

                Debug.WriteLine("[App]: successful");

            }
            catch (Exception e)
            {
                Debug.WriteLine("[App]: Failed - " + e.Message);
                throw;
            }

            return new List<WeatherForecast>();
        }
    }
}
