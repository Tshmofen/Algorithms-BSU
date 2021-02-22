using FiretruckPlacing.Algorithms;
using System;

namespace FiretruckPlacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = int.MaxValue;

            int[][] matrix =
            {
                new int[] { M, 7, 4,  M },
                new int[] {12, M, 5, 10 },
                new int[] { 2, M, M,  5 },
                new int[] { 4, M, 6,  M }
            };
            Graph graph = new Graph(matrix);
            Console.WriteLine(MatrixPrinter.MatrixToPrettyString(matrix));
            (int, int) vertAndDist = Floid.GetTheBestBaseVertexAndDistance(graph);
            Console.WriteLine($"The best vertex: {vertAndDist.Item1 + 1}");
            Console.WriteLine($"The best distance: {vertAndDist.Item2}");
            Console.WriteLine("\n=================\n");

            for(int i = 0; i < graph.Count; i++)
            {
                Console.WriteLine($"Vertex {i + 1} - Max shortest path = {Dijkstra.GetMaxShortestPath(graph.Contiguity, i)}");
            }

            Console.ReadKey();
        }
    }
}
