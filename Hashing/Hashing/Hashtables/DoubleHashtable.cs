using Hashing.Util;
using System.Collections.Generic;

namespace Hashing.Hashtables
{
    public class DoubleHashtable : CommonHashtable<int, string>
    {
        // 0 < A < 1, Optimal A is  (Math.Sqrt(5) - 1) / 2 =~ 0.6180339887
        private readonly double A; // multiplication coefficient
        private readonly TableItem[] values;
        private readonly List<int> deletedKeys;

        public DoubleHashtable(int tableCapacity = 255, double A = 0.6180339887)
        {
            this.values = new TableItem[tableCapacity];
            this.deletedKeys = new List<int>();
            this.A = A;
        }

        public bool Insert(int key, string value)
        {
            int hash = HashCalculation.GetDoubleHash(values.Length, key, 0, A);
            int index = hash;
            for(int iter = 1; values[index] != null; iter++)
            {
                if (index == hash && iter != 1)
                {
                    return false;
                }
                if (values[index] != null && deletedKeys.Contains(values[index].Key))
                {
                    break;
                }
                index = HashCalculation.GetDoubleHash(values.Length, key, iter, A);
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
            int hash = HashCalculation.GetDoubleHash(values.Length, key, 0, A);
            int index = hash;
            for (int iter = 1; values[index] != null; iter++)
            {
                if (index == hash && iter != 1)
                {
                    break;
                }
                if (values[index].Key == key)
                {
                    return values[index];
                }
                index = HashCalculation.GetDoubleHash(values.Length, key, iter, A);
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
