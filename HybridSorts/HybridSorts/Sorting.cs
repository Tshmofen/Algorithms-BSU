using System.Collections.Generic;

namespace HybridSorts
{
    public class Sorting
    {
        public static int magicNumber = 10;

        public static void QuickSort(int[] array, int lowInd, int topInd)
        {
            if (topInd - lowInd + 1 < magicNumber) // 3
            {
                InsertionSort(array, lowInd, topInd);
                return;
            }

            if (lowInd < topInd) // 2
            {
                int border = FindBorder(array, lowInd, topInd);
                QuickSort(array, lowInd, border - 1);
                QuickSort(array, border + 1, topInd);
            }
        }

        public static void MergeSort(int[] array, int lowInd, int topInd)
        {
            if (topInd - lowInd + 1 < magicNumber) // 3 
            {
                InsertionSort(array, lowInd, topInd);
                return;
            }

            if (lowInd < topInd) // 2
            {
                // dividing into pieces
                int border = (lowInd + topInd) / 2; // 3
                MergeSort(array, lowInd, border);
                MergeSort(array, border + 1, topInd);

                Merge(array, lowInd, border, topInd);
            }
        }

        private static void Merge(int[] array, int lowInd, int border, int topInd)
        {
            List<int> tempArray = new List<int>(); // 1

            // copy elements in temp array in sorted order
            int i = lowInd, j = border + 1; // 2
            while (i <= border && j <= topInd) // (8) * n
            {
                if (array[i] < array[j]) // 4
                {
                    tempArray.Add(array[i]); // 2
                    i++; // 2
                }
                else
                {
                    tempArray.Add(array[j]); // 2
                    j++; // 2
                }
            }

            // take care of the remaining elements
            while (i <= border)
            {
                tempArray.Add(array[i]); // 2
                i++; // 2
            }

            while (j <= topInd)
            {
                tempArray.Add(array[j]); // 2
                j++; // 2
            }

            // copy tempArray values to previous array
            for (int h = lowInd, k = 0; h <= topInd; h++, k++)
            {
                array[h] = tempArray[k]; // 3
            }
        }

        // Lomuto's algorithm, (10 + 13 * n) ~ O(n)
        private static int FindBorder(int[] array, int lowInd, int topInd)
        {
            // take last element as pivot
            int pivot = array[topInd]; // 2

            int border = lowInd; // 1
            // 1
            for (int i = lowInd; i < topInd; i++) // (2 + 11) * n
            {
                if (array[i] <= pivot) // 3
                {
                    Swap(ref array[i], ref array[border]); // 6
                    border++; // 2
                }
            }
            Swap(ref array[border], ref array[topInd]); // 6
            return border;
        }

        private static void InsertionSort(int[] array, int lowInd, int topInd)
        {
            for (int left = lowInd; left <= topInd; left++) // 1 + (6 + 9 * (i - lowInd)) * (topInd - lowInd) <= ~ O(n^2)
            {
                int value = array[left]; // 2
                int i = left - 1; // 2
                while (i >= lowInd) // 9 * (i - lowInd)
                {
                    if(value >= array[i]) // 3 
                    {
                        break;
                    }
                    array[i + 1] = array[i]; // 3
                    i--; // 2
                }
                array[i + 1] = value; // 2
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
