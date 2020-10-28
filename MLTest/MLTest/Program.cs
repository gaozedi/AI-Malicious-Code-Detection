using MLTestML.Model;
using System;
using System.Linq;

namespace MLTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add input data
            var input = new ModelInput();
            input.Code = "while(true)";

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            Console.WriteLine($"Text: {input.Code}\nIs Toxic: {result.Prediction}");

        }
    }
}
