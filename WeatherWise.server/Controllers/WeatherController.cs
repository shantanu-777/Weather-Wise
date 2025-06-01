﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherWise.server.Service;

namespace WeatherWise.server.Controllers
{
    
    [Route("api/v{version:apiVersion}/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        
        [HttpGet("search")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWeatherByCity([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest(new { message = "City name is required." });
            }

            var weatherData = await _weatherService.GetWeatherByCity(city);
            if (weatherData == null)
            {
                return NotFound(new { message = "Weather data not available." });
            }

            return Ok(weatherData);
        }

        
        [HttpGet("forecast")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWeatherForecast([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest(new { message = "City name is required." });
            }

            var forecast = await _weatherService.GetWeatherForecastByCity(city);
            if (forecast == null)
            {
                return NotFound(new { message = "Weather forecast not available." });
            }

            return Ok(forecast);
        }

        
        [HttpGet("current-location")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWeatherByLocation([FromQuery] double lat, [FromQuery] double lon)
        {
            if (lat == 0 || lon == 0)
            {
                return BadRequest(new { message = "Latitude and Longitude are required." });
            }

            var weatherData = await _weatherService.GetWeatherByCoordinates(lat, lon);
            if (weatherData == null)
            {
                return NotFound(new { message = "Weather data not available." });
            }

            return Ok(weatherData);
        }
    }
}
