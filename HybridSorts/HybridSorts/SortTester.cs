using System;

namespace HybridSorts
{
    class SortTester
    {
        private int arraysNum;
        private int arraySize;
        private int arrayMaxElement;

        // this sorting should be in Sorting class and use magicNumber
        public delegate void GeneralSorting(int[] array, int lowInd, int topInd);

        public SortTester(int arraysNum, int arraySize, int arrayMaxElement)
        {
            this.arraysNum = arraysNum;
            this.arraySize = arraySize;
            this.arrayMaxElement = arrayMaxElement;
        }

        public static void Main(string[] args)
        {
            SortTester tester = new SortTester(50, 100000, int.MaxValue);
            tester.CountMagicNumberForQuickSort(Sorting.MergeSort);
            Console.ReadKey();
        }

        public int CountMagicNumberForQuickSort(GeneralSorting generalSorting)
        {
            int[][] arrays = ArrayGenerator.GenerateArrays(arraysNum, arraySize, arrayMaxElement);

            int minK = 1;
            double minTime = double.MaxValue;

            // check time of sorting for each magicNumber
            for (int k = 1; k <= 75; k++)
            {
                Sorting.magicNumber = k;
                int[][] clonedArrays= ArrayGenerator.CopyArrayOfArrays(arrays);
                DateTime startTime = DateTime.Now;
                for (int i = 0; i < arraysNum; i++)
                {
                    generalSorting(clonedArrays[i], 0, arraySize - 1);
                }
                DateTime endTime = DateTime.Now;

                double averageTimePerArray = (endTime - startTime).TotalMilliseconds / arraysNum;
                Console.WriteLine($"Magic k = {k}, average time per array = { averageTimePerArray } ms\n");

                if (averageTimePerArray < minTime)
                {
                    minK = k;
                    minTime = averageTimePerArray;
                }
            }

            Console.WriteLine($"\nMinimal k = {minK}, minimal average time = {minTime}");
            return minK;
        }
    }
}
