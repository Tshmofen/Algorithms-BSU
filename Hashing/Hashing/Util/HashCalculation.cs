using System;

namespace Hashing.Util
{
    public static class HashCalculation
    {
        // 0 < A < 1, Optimal is  (Math.Sqrt(5) - 1) / 2 =~ 0.6180339887
        public static int GetHash(int tableSize, int key, double A = 0.6180339887)
        {
            return (int)(tableSize * ((Math.Abs(key) * A) % 1));
        }
         
        public static int GetDivisionHash(int tableSize, int key)
        {
            return key % tableSize;
        }

        public static int GetDoubleHash(int tableSize, int key, double iteration = 1, double A = 0.6180339887)
        {
            return (int)((GetHash(tableSize, key, A) + iteration * GetDivisionHash(tableSize, key)) % tableSize);
        }
    }
}
