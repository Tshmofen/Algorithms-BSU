using System;

namespace QuickSortHybrid
{
    class SortTester
    {
        private static int ARRAYS_NUM = 1000;
        private static int ARRAY_SIZE = 10000;
        private static int ARRAY_MAX_ELEMENT = 10000;

        public static void Main(string[] args)
        {
            int[][] arrays = ArrayGenerator.GenerateArrays(ARRAYS_NUM, ARRAY_SIZE, ARRAY_MAX_ELEMENT);

            int minK = 1;
            double minTime = double.MaxValue;

            for (int k = 1; k <= 40; k++)
            {
                Sorting.magicNumber = k;
                DateTime startTime = DateTime.Now;
                for (int i = 0; i < ARRAYS_NUM; i++)
                {
                    Sorting.QuickSort((int[])arrays[i].Clone(), 0, ARRAY_SIZE - 1);
                }
                DateTime endTime = DateTime.Now;

                double averageTimePerArray = (endTime - startTime).TotalMilliseconds / ARRAYS_NUM;
                Console.WriteLine($"Magic k = {k}, average time per array = { averageTimePerArray }\n");

                if(averageTimePerArray < minTime)
                {
                    minK = k;
                    minTime = averageTimePerArray;
                }
            }

            Console.WriteLine($"\nMinimal k = {minK}, minimal average time = {minTime}");
            Console.ReadKey();
        }

        
    }
}
