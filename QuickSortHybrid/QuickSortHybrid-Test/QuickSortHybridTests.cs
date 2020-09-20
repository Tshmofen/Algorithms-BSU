using NUnit.Framework;
using System.Runtime.Serialization.Formatters;

namespace QuickSortHybrid.Tests
{
    [TestFixture]
    public class QuickSortHybridTests
    {
        [TestCase(new[] { 1, 8, 3, 2, 9 }, new[] { 1, 2, 3, 8, 9 })]
        public void QuickSortSimpleArrayTest(int[] array, int[] expected)
        {
            Sorting.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(array, expected);
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsOne()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 1;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsThree()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 3;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsFive()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 5;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsSeven()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 7;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsNine()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 9;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsTen()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 10;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsEleven()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 11;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsThirteen()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 13;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsFifteen()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 15;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsSeventeen()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 17;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsNineteen()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 19;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }

        [Test]
        [Timeout(20000)]
        public void QuickSortTimeTestMagicIsTwentyFive()
        {
            ArrayGenerator.GenerateArrays(10000, 10000, 10000);
            Sorting.magicNumber = 26;
            for (int i = 0; i < 10000; i++)
            {
                Sorting.QuickSort(ArrayGenerator.GetArray(), 0, 9999);
            }
        }
    }
}