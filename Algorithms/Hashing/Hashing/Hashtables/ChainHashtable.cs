using Hashing.Util;
using System.Collections.Generic;

namespace Hashing.Hashtables
{
    public class ChainHashtable : CommonHashtable<int, string>
    {
        // 0 < t < 1, Optimal is  (Math.Sqrt(5) - 1) / 2 =~ 0.6180339887
        private readonly double A; // Multiplication Coefficient
        private readonly List<TableItem>[] values;

        public ChainHashtable(int tableCapacity = 255, double A = 0.6180339887)
        {
            this.values = new List<TableItem>[tableCapacity];
            this.A = A;
        }

        public bool Insert(int key, string value)
        {
            if (Search(key) != null)
            {
                return false;
            }

            int hash = HashCalculation.GetHash(values.Length, key, A);
            if (values[hash] == null)
            {
                values[hash] = new List<TableItem>();
            }
            values[hash].Add(new TableItem(key, value));
            return true;
        }

        public string Search(int key)
        {
            int hash = HashCalculation.GetHash(values.Length, key, A);
            if (values[hash] == null)
            {
                return null;
            }

            foreach (TableItem item in values[hash])
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public bool Delete(int key)
        {
            int hash = HashCalculation.GetHash(values.Length, key, A);
            if (values[hash] == null)
            {
                return false;
            }

            foreach (TableItem item in values[hash])
            {
                if (item.Key == key)
                {
                    return values[hash].Remove(item);
                }
            }

            return false;
        }
    }
}
