// This file was auto-generated by ML.NET Model Builder. 

using System;
using MLAPITestML.Model;

namespace MLAPITestML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Malicious = @"int a; ",
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Code with predicted Code from sample data...\n\n");
            Console.WriteLine($"Malicious: {sampleData.Malicious}");
            Console.WriteLine($"\n\nPredicted Code value {predictionResult.Prediction} \nPredicted Code scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
