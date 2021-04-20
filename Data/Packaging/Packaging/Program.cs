using System;
using System.Collections.Generic;

namespace Packaging
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
            var fastFitSize = ContainerManager.PerformFastFit(numbers).Count;
            var fastFitDownSize = ContainerManager.PerformFastFitDecrease(numbers).Count;
            var bestFitSize = ContainerManager.PerformBestFit(numbers).Count;
            
            Console.WriteLine($"Next fit, containers size = {nextFitSize}");
            Console.WriteLine($"Fast fit, containers size = {fastFitSize}");
            Console.WriteLine($"Fast fit decrease, containers size = {fastFitDownSize}");
            Console.WriteLine($"Best fit, containers size = {bestFitSize}");
        }
    }
}