using Hashing.Util;
using System.Collections.Generic;

namespace Hashing.Hashtables
{
    public class ProbingHashtable : CommonHashtable<int, string>
    {
        // 0 < A < 1, Optimal is  (Math.Sqrt(5) - 1) / 2 =~ 0.6180339887
        private readonly double A; // multiplication coefficient
        private readonly TableItem[] values;
        private readonly List<int> deletedKeys;

        public ProbingHashtable(int tableCapacity = 255, double A = 0.6180339887)
        {
            this.values = new TableItem[tableCapacity];
            this.deletedKeys = new List<int>();
            this.A = A;
        }

        public bool Insert(int key, string value)
        {
            int hash = HashCalculation.GetHash(values.Length, key, A);
            int index = hash;
            while(values[index % values.Length] != null)
            {
                if ((index + 1) % values.Length == hash)
                {
                    return false;
                }
                if (values[index % values.Length].Key == key)
                {
                    return false;
                }
                if (deletedKeys.Contains(values[index % values.Length].Key))
                {
                    break;
                }
                index++;
            }
            values[index] = new TableItem(key, value);
            return true;
        }

        public string Search(int key)
        {
            return SearchItem(key)?.Value;
        }

        private TableItem SearchItem(int key)
        {
            if (deletedKeys.Contains(key))
            {
                return null;
            }
            int hash = HashCalculation.GetHash(values.Length, key, A);
            int index = hash;
            while (values[index % values.Length] != null)
            {
                if ((index + 1) % values.Length == hash)
                {
                    break;
                }
                if (values[index % values.Length].Key == key)
                {
                    return values[index % values.Length];
                }
                index++;
            }
            return null;
        }

        public bool Delete(int key)
        {
            if (SearchItem(key) != null)
            {
                deletedKeys.Add(key);
                return true;
            }
            return false;
        }
    }
}
