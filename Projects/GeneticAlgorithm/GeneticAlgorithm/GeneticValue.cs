using System;

namespace GeneticAlgorithm
{
    public class GeneticValue
    {
        public const int Count = 5; 
        
        public int X;
        public int Y;
        public int Z;
        public int U;
        public int W;

        public int this[int i]
        {
            get => i switch
                {
                    0 => X,
                    1 => Y,
                    2 => Z,
                    3 => U,
                    4 => W,
                    _ => throw new IndexOutOfRangeException()
                };

            set
            {
                switch (i)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    case 3: U = value; break;
                    case 4: W = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public GeneticValue Clone() => new(X, Y, Z, U, W);

        public void Copy(GeneticValue value)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            U = value.U;
            W = value.W;
        }

        public GeneticValue(int x, int y, int z, int u, int w)
        {
            X = x;
            Y = y;
            Z = z;
            U = u;
            W = w;
        }

        public override string ToString() => $"({X}, {Y}, {Z}, {U}, {W})";
    }
}