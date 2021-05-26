using System;

namespace GeneticAlgorithm
{
    internal static class Program
    {
        private static void Main()
        {
            Selecting.ActionTarget target = Targets.GetTargetEquationB;

            const int populationSize = 3000;          
            const int valueMin = -200;                
            const int valueMax = 200;                
            const int valuesForSelection = 2000;
            const int valuesForMutation = 800;
            const double mutationChance = 0.5;
            const double substitutionChance = 0.5;

            var geneticAlgorithm = new Selecting(
                    target,
                    populationSize,
                    valueMin,
                    valueMax,
                    valuesForSelection,
                    valuesForMutation,
                    mutationChance,
                    substitutionChance
            );

            Console.WriteLine(geneticAlgorithm.UseGeneticSelecting());
        }
    }
}