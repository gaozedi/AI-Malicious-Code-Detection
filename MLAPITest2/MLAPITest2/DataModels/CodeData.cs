using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;
namespace MLAPITest2.DataModels
{
    public class CodeData
    {
        [ColumnName("Malicious"), LoadColumn(0)]
        public string Malicious { get; set; }


        [ColumnName("Code"), LoadColumn(1)]
        public string Code { get; set; }


    }
}
