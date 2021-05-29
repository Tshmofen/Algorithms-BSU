using System;

namespace FiretruckPlacing.Algorithms
{
    public static class MatrixMinimizer
    {
        public static int[][] GetMinimizedMatrix(int[][] matrix)
        {
            int[][] minMatrix = new int[matrix.Length][];
            for (int i = 0; i < minMatrix.Length; i++)
            {
                minMatrix[i] = (int[])matrix[i].Clone();
            }

            // firetruck can use both roads
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i + 1; j < matrix.Length; j++)
                {
                    minMatrix[j][i] = minMatrix[i][j] = Math.Min(minMatrix[i][j], minMatrix[j][i]);
                }
            }

            return minMatrix;
        }
    }
}
