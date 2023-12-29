using Microsoft.AspNetCore.Mvc;
using SimpleApiDI.Services;
using SimpleApiDI.Services.Interfaces;

namespace SimpleApiDI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOperationTransient _transient;
    private readonly IOperationScoped _scoped;
    private readonly IOperationSingleton _singleton;
    private readonly FirstService _firstService;
    private readonly SecondService _secondService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOperationTransient transient,
        IOperationScoped scoped, IOperationSingleton singleton, FirstService firstService, SecondService secondService)
    {
        _logger = logger;
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
        _firstService = firstService;
        _secondService = secondService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation($"Transient: {_transient.OperationId}");
        _logger.LogInformation($"Scoped: {_scoped.OperationId}");
        _logger.LogInformation($"Singleton: {_singleton.OperationId}");
        _firstService.GenerateResult();
        _secondService.GenerateResult();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}