using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MLAPITestML.Model;

namespace MLAPITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaliciousCodeController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<MaliciousCodeController> _logger;

        public MaliciousCodeController(ILogger<MaliciousCodeController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        [HttpPost]
        public IActionResult GETTestCode(InputVM code)
        {
            ModelInput sampleData = new ModelInput()
            {
                Malicious = code.Code,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);
            return Ok(new
            {
                Code = code.Code,
                Malicious = sampleData.Malicious,
                Perdiction = predictionResult.Prediction,
                Score = $"[{String.Join(",", predictionResult.Score)}]"
            }); ; 
        }
    }
}
