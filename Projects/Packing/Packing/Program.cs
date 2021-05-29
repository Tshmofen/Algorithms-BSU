using System;
using System.Collections.Generic;

namespace Packing
{
    internal static class Program
    {
        private static void Main()
        {
            const int numbersAmount = 10000;
            var random = new Random();
            
            var numbers = new List<double>();
            for (var i = 0; i < numbersAmount; i++)
                numbers.Add(random.NextDouble() % 1);

            PerformFits(numbers);
        }

        private static void PerformFits(IReadOnlyCollection<double> numbers)
        {
            var nextFitSize = ContainerManager.PerformNextFit(numbers).Count;
            var fastFitSize = ContainerManager.PerformFirstFit(numbers).Count;
            var fastFitDownSize = ContainerManager.PerformFirstFitDecrease(numbers).Count;
            var bestFitSize = ContainerManager.PerformBestFit(numbers).Count;
            
            Console.WriteLine($"Next fit, containers size = {nextFitSize}");
            Console.WriteLine($"First fit, containers size = {fastFitSize}");
            Console.WriteLine($"First fit decrease, containers size = {fastFitDownSize}");
            Console.WriteLine($"Best fit, containers size = {bestFitSize}");
        }
    }
}