using NUnit.Framework;

namespace Searching.Test
{
    [TestFixture]
    public class SearchingTests
    {
        [TestCase(new[] { 1, 2, 4, 16, 84, 85, 86, 777}, 85, 5)]
        [TestCase(new[] { 1, 2, 4, 16, 84, 85, 86, 777 }, 13, -1)]
        [TestCase(new[] { 1, 2, 3, 5, 6, 7, 8, 9 }, 4, -1)]
        public void BinarySearchIsRightIndex(int[] array, int key, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, Searching.BinarySearch(array, key));
        }

        [TestCase(new[] { 1, 2, 4, 16, 84, 85, 86, 777 }, 85, 5)]
        [TestCase(new[] { 1, 2, 4, 16, 84, 85, 86, 777 }, 13, -1)]
        [TestCase(new[] { 1, 2, 3, 5, 6, 7, 8, 9 }, 4, -1)]
        public void InterpolationSearchIsRightIndex(int[] array, int key, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, Searching.InterpolationSearch(array, key));
        }
    }
}