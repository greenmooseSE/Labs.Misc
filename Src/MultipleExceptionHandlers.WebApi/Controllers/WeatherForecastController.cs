using Microsoft.AspNetCore.Mvc;

using MultipleExceptionHandlers.WebApi.Exceptions;

namespace MultipleExceptionHandlers.WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class WeatherForecastController : ControllerBase
{
    #region Public members

    [HttpGet("~/v1/[controller]/{id?}", Name = "GetWeatherForecast2")]
    public IEnumerable<WeatherForecast> Get(string? id)
    {
        if (id == "0")
        {
            throw new ItemNotFoundException();
        }
        else if (id == "666")
        {
            throw new SecretDataException();
        }

        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            })
            .ToArray();
    }

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    #endregion

    #region Non-Public members

    private readonly ILogger<WeatherForecastController> _logger;

    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
        "Scorching",
    };

    #endregion
}



