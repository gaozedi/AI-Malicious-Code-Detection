// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace MLTestML.Model
{
    public class ModelInput
    {
        [ColumnName("Malicious"), LoadColumn(0)]
        public string Malicious { get; set; }


        [ColumnName("Code"), LoadColumn(1)]
        public string Code { get; set; }


        [ColumnName("Dump"), LoadColumn(2)]
        public bool Dump { get; set; }


    }
}
