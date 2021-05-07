using System;
using StaticAnalysisDemo.Refactoring.models;

namespace StaticAnalysisDemo.Refactoring
{
    public class CalculatorService
    {
        public int GetTaskDurationInHours(RelativeTaskSize taskSize)
        {
            switch (taskSize)
            {
                case RelativeTaskSize.Small:
                    return 3;
                case RelativeTaskSize.Medium:
                    return 10;
                case RelativeTaskSize.Large:
                    return 100;
                default:
                    return 30;
            }
        }
        
        public void PrintDataCenterLocations()
        {
            var cities = new[] { "Amsterdam", "London"};

            for (var i = 0; i < cities.Length; i++)
            {
                Console.WriteLine($"Hello from {cities[i]}");
            }
        }
    }
}