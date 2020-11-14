using System.Linq;
using System.Collections.Generic;

namespace FiretruckPlacing.Algorithms
{
    public static class Dijkstra
    {
        public static (int,int) GetTheBestBaseVertexAndDistance(Graph graph)
        {
            int minVertex = int.MaxValue;
            int minDistance = int.MaxValue;
            for(int i = 0; i < graph.Count; i++)
            {
                int tempDistance = GetMaxShortestPath(graph.Contiguity, i);
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    minVertex = i;
                }
            }
            return (minVertex, minDistance);
        }

        public static int GetMaxShortestPath(int[][] matrix, int fromVertex)
        {
            matrix = MatrixMinimizer.GetMinimizedMatrix(matrix);

            bool[] used = new bool[matrix.Length];
            int usedCount = 0;
            int[] distances = new int[matrix.Length];
            Queue<int> vertexQueue = new Queue<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                distances[i] = int.MaxValue;
                used[i] = false;
                vertexQueue.Enqueue(i);
            }
            distances[fromVertex] = 0;

            while (vertexQueue.Count != 0)
            {
                int vertex = vertexQueue.Dequeue();
                while (vertexQueue.Count != 0 && (used[vertex] || distances[vertex] == int.MaxValue))
                {
                    vertex = vertexQueue.Dequeue();
                }

                used[vertex] = true;
                usedCount++;
                for (int i = 0; i < matrix[vertex].Length; i++)
                {
                    int neighbor = i;
                    if (matrix[vertex][neighbor] == int.MaxValue)
                    {
                        continue;
                    }
                    int newDistance = distances[vertex] + matrix[vertex][neighbor];
                    if (!used[neighbor] && newDistance < distances[neighbor])
                    {
                        distances[neighbor] = newDistance;
                        vertexQueue.Enqueue(neighbor);
                    }
                }
            }

            return distances.Max();
        }
    }
}
