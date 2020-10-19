using System;

namespace Searching
{
    public class Searching
    {
        public static int Comparings { get; set; }

        public static int BinarySearch(int[] array, int key)
        {
            int index = -1;
            int left = 0;
            int right = array.Length - 1;

            Comparings = 0; // task 2.1
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (array[mid] < key)
                {
                    Comparings++; // task 2.1
                    left = mid + 1;
                }
                else if (array[mid] > key)
                {
                    Comparings+=2; // task 2.1
                    right = mid - 1;
                }
                else if (array[mid] == key)
                {
                    Comparings+=3; // task 2.1
                    index = mid;
                    break;
                }
            }

            return index;
        }

        public static int InterpolationSearch(int[] array, int key)
        {
            int index = -1;
            int left = 0;
            int right = array.Length - 1;

            Comparings = 0; // task 2.1
            while (left < right && (key >= array[left]) && (key <= array[right]))
            {
                int mid = (int)Math.Round(left + ((double)(key - array[left]) * (right - left) / (array[right] - array[left])));

                if (array[mid] < key)
                {
                    Comparings++; // task 2.1
                    left = mid + 1;
                }
                else if (array[mid] > key)
                {
                    Comparings += 2; // task 2.1
                    right = mid - 1;
                }
                else 
                {
                    Comparings += 3; // task 2.1
                    index = mid;
                    break;
                }
            }

            return index;
        }
    }
}
