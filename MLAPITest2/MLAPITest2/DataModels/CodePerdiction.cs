using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
namespace MLAPITest2.DataModels
{
    public class CodePerdiction
    {
        [ColumnName("PredictedLabel")]
        public string Prediction { get; set; }


        public float[] Score { get; set; }
    }
}
