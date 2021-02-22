using System;
using System.Linq;

namespace FiretruckPlacing.Algorithms
{
    class Floid
    {
        public static (int, int) GetTheBestBaseVertexAndDistance(Graph graph)
        {
            int inf = int.MaxValue;
            int[][] matrix = MatrixMinimizer.GetMinimizedMatrix(graph.Contiguity);

            for (int k = 0; k < matrix.Length; k++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix.Length; j++)
                    {
                        if ((matrix[i][k] == inf || matrix[k][j] == inf) || (k == j || k == i))
                        {
                            continue;
                        }
                        if (matrix[i][j] > matrix[i][k] + matrix[k][j])
                        {
                            matrix[i][j] = matrix[i][k] + matrix[k][j];
                        }
                    }
                }
            }

            int minVertex = int.MaxValue;
            int minDistance = int.MaxValue;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][i] = 0; // to not get path from vertex to itself
                int tempDistance = matrix[i].Max();
                if (tempDistance < minDistance)
                {
                    minDistance = tempDistance;
                    minVertex = i;
                }
            }
            return (minVertex, minDistance);
        }
    }
}
