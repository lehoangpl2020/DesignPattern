using IEnumerablePattern.Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEnumerablePatterj.Controllers
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

        //private readonly IEnumerable<INotifier> _notifiers;
        private readonly INotifierMediatorService _notifierMediatorService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger
            //, IEnumerable<INotifier> notifiers
            , INotifierMediatorService notifierMediatorService)
        {
            _logger = logger;
            //_notifiers = notifiers;
            _notifierMediatorService = notifierMediatorService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //_notifiers.ToList().ForEach(x => x.Notify());
            _notifierMediatorService.Notify();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
