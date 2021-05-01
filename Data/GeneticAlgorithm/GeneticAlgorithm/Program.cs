using System;

namespace GeneticAlgorithm
{
    internal static class Program
    {
        private static void Main()
        {
            const int populationSize = 3000;          
            const int valueMin = -200;                
            const int valueMax = 200;                
            const int valuesForSelection = 2000;
            const int valuesForMutation = 800;
            const double mutationChance = 0.5;

            var geneticAlgorithm = new Selecting(
                    populationSize,
                    valueMin,
                    valueMax,
                    valuesForSelection,
                    valuesForMutation,
                    mutationChance
            );

            Console.WriteLine(geneticAlgorithm.UseGeneticSelecting());
        }
    }
}