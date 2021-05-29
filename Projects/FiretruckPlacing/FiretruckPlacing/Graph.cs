namespace FiretruckPlacing
{
    public class Graph
    {
        public int[][] Contiguity { get; }

        public int Count { get => Contiguity.Length; }

        public Graph(int size = 0)
        {
            Contiguity = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Contiguity[i] = new int[size];
            }
        }

        public Graph(int[][] contiguity)
        {
            this.Contiguity = contiguity;
        }
    }
}
