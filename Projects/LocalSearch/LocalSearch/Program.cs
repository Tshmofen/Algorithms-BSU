using System;
using System.Collections.Generic;

namespace LocalSearch
{
    internal static class Program
    {
        private static void Main()
        {
            const int size = 15;
            const int maxValue = 100;
            
            var weights = GenerateWeightsMatrix(size, maxValue);
            var solver = new SalesmenProblemSolver(weights);
            
            Console.WriteLine("Weights matrix:");
            Console.WriteLine(MatrixPrinter.MatrixToString(weights));
            Console.WriteLine("-----");
            
            var previousRoute = (List<int>)null;
            var currentRoute = solver.GetRandomRoute();
            while (previousRoute != currentRoute)
            {
                previousRoute = currentRoute;
                var ( minWeight, minRoute, log) = solver.PerformSearch(currentRoute);
                currentRoute = minRoute;
                Console.WriteLine($"{minWeight} – {SalesmenProblemSolver.RouteToString(currentRoute)}");
            }
        }
        
        private static List<List<int>> GenerateWeightsMatrix(int size, int maxValue)
        {
            var random = new Random();
            var weights = new List<List<int>>();
            
            for (var i = 0; i < size; i++)
            {
                weights.Add(new List<int>());
                for (var j = 0; j < size; j++)
                    weights[i].Add(random.Next(1, maxValue));
            }

            for (var i = 1; i < size; i++)
                for (var j = 0; j < i; j++)
                    weights[i][j] = weights[j][i];

            return weights;
        }
    }
}