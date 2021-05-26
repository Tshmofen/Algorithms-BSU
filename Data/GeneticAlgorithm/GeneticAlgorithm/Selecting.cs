using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticAlgorithm
{
    public class Selecting
    {
        #region Static members
        
        private static readonly Random Random = new();

        // we have 5 elements and should use some intermediate border, specifically from 1 to 3 (as index)
        private static int GenerateBorder() => Random.Next(3) + 1;
        
        private static (GeneticValue, GeneticValue) UseOnePointCrossover(GeneticValue valueA, GeneticValue valueB)
        {
            var border = GenerateBorder();

            var newValueA = valueA.Clone();
            for (var i = border; i < GeneticValue.Count; i++)
                newValueA[i] = valueB[i];
            
            var newValueB = valueB.Clone();
            for (var i = border; i < GeneticValue.Count; i++)
                newValueB[i] = valueA[i];

            return (newValueA, newValueB);
        }
        
        private static (GeneticValue, GeneticValue) UseMultiPointCrossover(GeneticValue valueA, GeneticValue valueB)
        {
            var (borderOne, borderTwo) = (GenerateBorder(), GenerateBorder());
            var borderMin = Math.Min(borderOne, borderTwo);
            var borderMax = Math.Max(borderOne, borderTwo);

            var newValueA = valueA.Clone();
            for (var i = borderMin; i <= borderMax; i++)
                newValueA[i] = valueB[i];
            
            var newValueB = valueB.Clone();
            for (var i = borderMin; i <= borderMax; i++)
                newValueB[i] = valueA[i];

            return (newValueA, newValueB);
        }
        
        private static List<GeneticValue> UseCrossing(List<GeneticValue> selected, bool oddIteration)
        {
            var childValues = new List<GeneticValue>();
            
            for (var i = 0; i + 1 <= selected.Count; i+=2)
            {
                var (childA, childB)
                    =  oddIteration ? 
                        UseOnePointCrossover(selected[i], selected[i + 1]) : 
                        UseMultiPointCrossover(selected[i], selected[i + 1]);
                childValues.Add(childA);
                childValues.Add(childB);
            }

            return childValues;
        }

        #endregion

        public delegate int ActionTarget(GeneticValue value);

        private readonly ActionTarget _target;
        private readonly int _populationSize;
        private readonly int _valueMin;
        private readonly int _valueMax;
        private readonly int _valuesForSelection;
        private readonly int _valuesForMutation;
        private readonly double _mutationChance;
        private readonly double _substitutionChance;

        private List<GeneticValue> _population;

        public Selecting(
            ActionTarget target,
            int populationSize,
            int valueMin,
            int valueMax,
            int valuesForSelection,
            int valuesForMutation,
            double mutationChance,
            double substitutionChance
            )
        {
            _target = target;
            
            _populationSize = populationSize;
            _valueMin = valueMin;
            _valueMax = valueMax;
            _valuesForSelection = valuesForSelection;
            _valuesForMutation = valuesForMutation;
            _mutationChance = mutationChance;
            _substitutionChance = substitutionChance;
            
            GenerateInitialPopulation();
        }

        public string UseGeneticSelecting()
        {
            var logBuilder = new StringBuilder();
            
            for(var iteration = 1;; iteration++)
            {
                var selected = UseRandomSelection();
                var childValues = UseCrossing(selected, iteration % 2 != 0);
                UseMutationForUnsuitable(childValues);
                UseSubstitution(childValues);

                var targets = _population
                    .AsEnumerable()
                    .Select(value => _target(value))
                    .ToList();
                var minValue = targets.Min();
                logBuilder.Append($"Minimal target = {minValue}, average target error = {targets.Average()}\n");

                if (minValue == 0)
                {
                    foreach (var value in _population)
                        if (_target(value) == 0)
                        {
                            logBuilder
                                .Append($"\n---------\n\nFinal value is = {value}\n")
                                .Append($"Number of iterations = {iteration}");
                            break;
                        }
                    break;
                }
            }

            return logBuilder.ToString();
        }

        private List<GeneticValue> UseRandomSelection()
        {
            // randomly shuffle array and then take values
            return _population
                .AsEnumerable()
                .OrderBy(_ => Random.NextDouble())
                .Take(_valuesForSelection)
                .ToList();
        }

        private void UseMutationForUnsuitable(List<GeneticValue> childValues)
        {
            var selected = childValues
                .AsEnumerable()
                .OrderByDescending(value => _target(value))
                .Take(_valuesForMutation);
            
            foreach (var value in selected)
            {
                for(var j = 0; j < GeneticValue.Count; j++)
                    if (Random.NextDouble() <= _mutationChance)
                        value[j] = GenerateValue();
            }
        }

        private void UseSubstitution(List<GeneticValue> childValues)
        {
            var chances = GenerateChances(childValues);
            foreach (var value in _population)
            {
                if (Random.NextDouble() > _substitutionChance) continue;
                    
                var random = Random.NextDouble();
                var index = 0;
                for (var j = 0; j < chances.Count; j++)
                {
                    if (random < chances[j])
                    {
                        index = j;
                        break;
                    }
                }
                
                value.Copy(childValues[index]);
                childValues.RemoveAt(index);
                chances.RemoveAt(index);
            }
        }
        
        private List<double> GenerateChances(List<GeneticValue> values)
        {
            var chances = new List<double>();
            var valuesFitness = new List<double>();
            var fitnessSum = 0d;
            
            foreach (var value in values)
            {
                var target = (double) _target(value);
                var fitness = 1 / (target == 0 ? 1 : target);
                fitnessSum += fitness;
                valuesFitness.Add(fitness);
            }
            
            for (var i = 0; i < values.Count; i++)
            {
                var fitness = valuesFitness[i];
                var chance = fitness / fitnessSum;
                chances.Add(chance);
            }

            return chances.OrderByDescending(chance => chance).ToList();
        }

        private void GenerateInitialPopulation()
        {
            _population = new List<GeneticValue>();
            for (var i = 0; i < _populationSize; i++)
                _population.Add(GenerateGeneticValue());
        }
        
        private GeneticValue GenerateGeneticValue()
        {
            return new(GenerateValue(), GenerateValue(), GenerateValue(), GenerateValue(), GenerateValue());
        }

        private int GenerateValue() => Random.Next(_valueMin, _valueMax);

    }
}