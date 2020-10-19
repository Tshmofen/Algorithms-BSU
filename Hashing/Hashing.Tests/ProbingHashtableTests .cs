using Hashing.Hashtables;
using NUnit.Framework;

namespace Hashing.Tests
{
    [TestFixture]
    public class ProbingHashtableTests
    {
        [TestCase(new[] { 5, 7, 999, 5, -11 }, new[] {"1", "2", "3", "4", "5"}, -7, null)]
        [TestCase(new[] { 5, 7, 999, 5, -11 }, new[] {"1", "2", "3", "4", "5"}, 5, "1")]
        public void FindAddedValueTest(int[] keys, string[] values , int keyToFind, string expectedResult)
        {
            ProbingHashtable table = new ProbingHashtable();
            for (int i = 0; i < keys.Length; i++)
            {
                table.Insert(keys[i], values[i]);
            }
            Assert.AreEqual(table.Search(keyToFind), expectedResult);
        }

        [TestCase(new[] { 5, 7, 999, 5, -11 }, new[] { "1", "2", "3", "4", "5" }, 5)]
        [TestCase(new[] { 5, 7, 999, 5, -11 }, new[] { "1", "2", "3", "4", "5" }, -11)]
        [TestCase(new[] { 5, 7, 999, 5, -11 }, new[] { "1", "2", "3", "4", "5" }, 333)]
        public void DeleteValueTest(int[] keys, string[] values, int keyToDelete)
        {
            ProbingHashtable table = new ProbingHashtable();
            for (int i = 0; i < keys.Length; i++)
            {
                table.Insert(keys[i], values[i]);
            }
            table.Delete(keyToDelete);
            Assert.IsNull(table.Search(keyToDelete));
        }

        [Test]
        public void FindDoubledValueTest()
        {
            ProbingHashtable table = new ProbingHashtable();
            table.Insert(1, "555");
            table.Insert(2, "555");
            table.Insert(1, "666");
            Assert.AreEqual(table.Search(1), "555");
        }

        [Test]
        public void DeleteDoubledValueTest()
        {
            ProbingHashtable table = new ProbingHashtable();
            table.Insert(1, "555");
            table.Insert(2, "555");
            table.Insert(1, "666");

            table.Delete(1);
            Assert.IsNull(table.Search(1));
        }
    }
}