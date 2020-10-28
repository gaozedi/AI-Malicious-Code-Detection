using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ML;
using MLAPITest2.DataModels;

namespace MLAPITest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictController : ControllerBase
    {
        private readonly PredictionEnginePool<CodeData, CodePerdiction> _predictionEnginePool;

        public PredictController(PredictionEnginePool<CodeData, CodePerdiction> predictionEnginePool)
        {
            _predictionEnginePool = predictionEnginePool;
        }

        [HttpPost]
        public ActionResult<string> Post( CodeData input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            CodePerdiction prediction = _predictionEnginePool.Predict(modelName: "MLModel", example: input);

         //   string sentiment = Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative";

            return Ok(new
            {
                prediction.Prediction,
                prediction.Score
            });
        }
    }
}
