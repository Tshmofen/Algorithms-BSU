﻿using System;
using System.Linq;

namespace HybridSorts
{
    public static class ArrayGenerator
    {
        public static int[][] GenerateArrays(int arraysNum, int arraySize, int maxElement)
        {
            Random random = new Random();
            int[][] generatedArrays = new int[arraysNum][];
            for (int i = 0; i < arraysNum; i++)
            {
                generatedArrays[i] = new int[arraySize];
                for (int j = 0; j < arraySize; j++)
                {
                    generatedArrays[i][j] = random.Next(maxElement);
                }
            }
            return generatedArrays;
        }
        public static int[][] CopyArrayOfArrays(int[][] source)
        {
            return source.Select(s => s.ToArray()).ToArray();
        }
    }
}
