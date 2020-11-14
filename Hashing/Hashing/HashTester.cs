using System;
using System.Linq;
using Hashing.Util;

namespace Hashing
{
    class HashTester
    {
        static void Main(string[] args)
        {
            int arraysNum = 30;
            int arraySize = 5000;
            int maxValue = 500;
            int tableSize = 2000;
            int[][] arrays = ArrayGenerator.GenerateArrays(arraysNum, arraySize, maxValue);
            double[] constans = new[]
            {
                0.6180339887,
                0.33333333,
                0.5,
                0.125,
                0.9131654,
                1
            };

            Console.WriteLine(
                $"Arrays number = {arraysNum}, each array size = {arraySize},\n"
                + $"maximal value = {maxValue}, table size = {tableSize}.\n"
                );    
            for (int i = 0; i < constans.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("--------------\n\nStandart constant is ((Math.Sqrt(5) - 1) / 2)");
                }
                Console.WriteLine(
                    $"Test for A = {constans[i]}\n" +
                    $"   In average chains have maximum length of " +
                    $"{GetAverageMaxChainLength(constans[i], tableSize, arrays)}\n"
                    );
                if (i == 0)
                {
                    Console.WriteLine("--------------\n\nSelecting better constant:\n");
                }
            }

            Console.WriteLine("--------------\n");
            double calculatedA = GetTheBestConst(tableSize, arrays, 10);
            Console.WriteLine(
                $"Calculated constant is {calculatedA}\n" +
                $"In average chains with that A have maximum length " +
                $"of {GetAverageMaxChainLength(calculatedA, tableSize, arrays)}"
                );
            Console.WriteLine("\n--------------");
            Console.ReadKey();
        }

        public static double GetAverageMaxChainLength(double constA, int tableSize, int[][] arrays)
        {
            int[] chains = new int[tableSize];
            foreach (int[] array in arrays)
            {
                foreach (int num in array)
                {
                    chains[HashCalculation.GetHash(tableSize, num, constA)]++;
                }
            }
            double[] averageChains = new double[tableSize];
            for (int i = 0; i < tableSize; i++)
            {
                averageChains[i] = (double)chains[i] / arrays.Length;
            }

            return averageChains.Max();
        }

        public static double GetTheBestConst(int tableSize, int[][] arrays
            , int maxDepth = 5, int depth = 0, double left = 0, double right = 1)
        {
            double leftMaxChain, centerMaxChain, rightMaxChain;
            double center = (left + right) / 2;

            if (depth == maxDepth)
            {
                leftMaxChain = GetAverageMaxChainLength(left, tableSize, arrays);
                centerMaxChain = GetAverageMaxChainLength((left + right) / 2, tableSize, arrays);
                rightMaxChain = GetAverageMaxChainLength(right, tableSize, arrays);

                if (centerMaxChain < rightMaxChain)
                {
                    return (leftMaxChain < centerMaxChain) ? left : center;
                }
                else
                {
                    return (leftMaxChain < rightMaxChain) ? left : right;
                }
            }

            double bestLeft = GetTheBestConst(tableSize, arrays, maxDepth, depth + 1, left, center);
            double bestRight = GetTheBestConst(tableSize, arrays, maxDepth, depth + 1, center, right);

            leftMaxChain = GetAverageMaxChainLength(bestLeft, tableSize, arrays);
            centerMaxChain = GetAverageMaxChainLength(center, tableSize, arrays);
            rightMaxChain = GetAverageMaxChainLength(bestRight, tableSize, arrays);


            if (centerMaxChain < rightMaxChain)
            {
                return (leftMaxChain < centerMaxChain) ? bestLeft : center;
            }
            else
            {
                return (leftMaxChain < rightMaxChain) ? bestLeft : bestRight;
            }
        }
    }
}
