using System;

namespace QuickSortHybrid
{
    public class Sorting
    {
        public static int magicNumber = 10;

        public static void QuickSort(int[] array, int lowInd, int topInd)
        {
            if (lowInd < topInd)
            {
                int partition = Partition(array, lowInd, topInd);

                // if size of the array is small enough, then it is more profitable to use insert sort
                if (partition - 1 - lowInd < magicNumber)
                {
                    InsertionSort(array, lowInd, partition - 1);
                }
                else
                {
                    QuickSort(array, lowInd, partition - 1);
                }

                if (topInd - partition - 1 < magicNumber)
                {
                    InsertionSort(array, partition + 1, topInd);
                }
                else
                {
                    QuickSort(array, partition + 1, topInd);
                }
            }
        }

        // Lomuto's algorithm
        private static int Partition(int[] array, int lowInd, int topInd)
        {
            // take last element as pivot
            int pivot = array[topInd];

            int partition = lowInd;
            for (int i = lowInd; i < topInd; i++)
            {
                if (array[i] <= pivot) 
                {
                    Swap(ref array[i], ref array[partition]);
                    partition++;
                }
            }
            Swap(ref array[partition], ref array[topInd]);
            return partition;
        }

        private static void InsertionSort(int[] array, int lowInd, int topInd)
        {
            for (int left = lowInd; left <= topInd; left++)
            {
                int value = array[left];
                int i = left - 1;
                while (i >= lowInd)
                {
                    if(value >= array[i])
                    {
                        break;
                    }
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = value;
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }
    }
}
