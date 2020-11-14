using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FiretruckPlacing
{
    public static class MatrixPrinter
    {
        public static string MatrixToPrettyString(int[][] matrix)
        {
            StringBuilder output = new StringBuilder();
            int width = matrix.Max(list => list.Select(val => val != int.MaxValue).Max()).ToString().Length + 1;
            output.Append(" ");
            for (int i = 0; i < matrix.Length + 1; i++)
            {
                output.Append(string.Format($"{{0, {width}}}", (i != 0) ? $"{i}" : "|"));
            }
            int outputOldLentgh = output.Length;
            output.Append("\n");
            for (int i = 0; i < outputOldLentgh; i++)
            {
                output.Append((i == width) ? "+" : "-");
            }
            output.Append("\n");
            for (int i = 0; i < matrix.Length; i++)
            {
                output.Append(string.Format($"{{0, {width + 1}}}", $"{i + 1} |"));
                foreach (int value in matrix[i])
                {
                    output.Append(string.Format($"{{0, {width}}}", (value == int.MaxValue) ? "M" : value.ToString()));
                }
                output.Append("\n");
            }
            return output.ToString();
        }
    }
}
