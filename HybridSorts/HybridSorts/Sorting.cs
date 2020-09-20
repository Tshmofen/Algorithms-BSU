using System.Collections.Generic;

namespace HybridSorts
{
    public class Sorting
    {
        public static int magicNumber = 10;

        public static void QuickSort(int[] array, int lowInd, int topInd)
        {
            if (topInd - lowInd + 1 < magicNumber)
            {
                InsertionSort(array, lowInd, topInd);
                return;
            }

            if (lowInd < topInd)
            {
                int border = FindBorder(array, lowInd, topInd);
                QuickSort(array, lowInd, border - 1);
                QuickSort(array, border + 1, topInd);
            }
        }

        public static void MergeSort(int[] array, int lowInd, int topInd)
        {
            if (topInd - lowInd + 1 < magicNumber)
            {
                InsertionSort(array, lowInd, topInd);
                return;
            }

            if (lowInd < topInd)
            {
                // dividing into pieces
                int border = (lowInd + topInd) / 2;
                MergeSort(array, lowInd, border);
                MergeSort(array, border + 1, topInd);

                Merge(array, lowInd, border, topInd);
            }
        }

        private static void Merge(int[] array, int lowInd, int border, int topInd)
        {
            List<int> tempArray = new List<int>();

            // copy elements in temp array in sorted order
            int i = lowInd, j = border + 1;
            while (i <= border && j <= topInd)
            {
                if (array[i] < array[j])
                {
                    tempArray.Add(array[i]);
                    i++;
                }
                else
                {
                    tempArray.Add(array[j]);
                    j++;
                }
            }

            // take care of the remaining elements
            while (i <= border)
            {
                tempArray.Add(array[i]);
                i++;
            }

            while (j <= topInd)
            {
                tempArray.Add(array[j]);
                j++;
            }

            // copy tempArray values to previous array
            for (int h = lowInd, k = 0; h <= topInd; h++, k++)
            {
                array[h] = tempArray[k];
            }
        }

        // Lomuto's algorithm
        private static int FindBorder(int[] array, int lowInd, int topInd)
        {
            // take last element as pivot
            int pivot = array[topInd];

            int border = lowInd;
            for (int i = lowInd; i < topInd; i++)
            {
                if (array[i] <= pivot) 
                {
                    Swap(ref array[i], ref array[border]);
                    border++;
                }
            }
            Swap(ref array[border], ref array[topInd]);
            return border;
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
