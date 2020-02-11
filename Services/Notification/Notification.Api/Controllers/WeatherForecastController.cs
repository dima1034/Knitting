using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notification.Api.Application.Commands;
using Notification.Api.Infrastructure;
using NotificationService.Email;

namespace Notification.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly EmailSenderService                 _service;

        public WeatherForecastController(
            EmailSenderService service,
            IMediator mediator,
            ILogger<WeatherForecastController> logger)
        {
            _service  = service;
            _logger   = logger;
            HangfireStaticRef.Mediator = mediator;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var command = new SendEmailCommand("dosta@softserveinc.com", "test", "hello, it is test message from Dima");
            BackgroundJob.Enqueue(() => HangfireStaticRef.Send(command));
            
            Console.WriteLine("CALLED THIS");
            // var jobId = BackgroundJob.Enqueue(
            //     () => Console.WriteLine("Fire-and-forget!"));
            
            var rng = new Random();

            return Enumerable.Range(1, 5)
                             .Select(
                                  index => new WeatherForecast
                                  {
                                      Date         = DateTime.Now.AddDays(index),
                                      TemperatureC = rng.Next(-20, 55),
                                      Summary      = Summaries[rng.Next(Summaries.Length)]
                                  })
                             .ToArray();
        }
    }
}