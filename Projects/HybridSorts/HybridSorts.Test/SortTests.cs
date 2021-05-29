using NUnit.Framework;
using HybridSorts;

namespace HybridSort.Test
{
    [TestFixture]
    public class SortTests
    {
        [TestCase(new[] { 2, 8, 3, 1, 9 }, new[] { 1, 2, 3, 8, 9 })]
        public void QuickSortSimpleArrayTest(int[] array, int[] expected)
        {
            Sorting.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(array, expected);
        }

        [TestCase(new[] { 1, 8, 3, 2, 9 }, new[] { 1, 2, 3, 8, 9 })]
        public void MergeSortSimpleArrayTest(int[] array, int[] expected)
        {
            Sorting.MergeSort(array, 0, array.Length - 1);
            Assert.AreEqual(array, expected);
        }
    }
}