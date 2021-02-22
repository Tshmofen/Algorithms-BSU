using HybridSorts;
using System;

namespace Searching
{
    class SearchTester
    {
        // this method should operate with Searching.Comparings variable
        public delegate int CommonSearching(int[] array, int key);

        static void Main(string[] args)
        {
            int arraySize = 500000;
            int maxValue = 50000;
            int key = 3333;
            Console.WriteLine($"Array size = {arraySize}, max value = {maxValue}, key = {key}\n" +
                $"Compare operations to find key:\n" + 
                $" 1. {CountCompareOperations(arraySize, maxValue, key, Searching.BinarySearch)} " +
                $"operations for Binary Search\n" + 
                $" 2. {CountCompareOperations(arraySize, maxValue, key, Searching.InterpolationSearch)} " +
                $"operations for Interpolation Search\n");
            Console.ReadKey();
        }

        public static int CountCompareOperations(int arraySize, int maxValue, int key, CommonSearching searching)
        {
            int[] array = ArrayGenerator.GenerateArray(arraySize, maxValue);
            Array.Sort(array);
            searching(array, key);
            return Searching.Comparings;
        }
    }
}
