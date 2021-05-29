using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalSearch
{
    public static class MatrixPrinter
    {
        public static string MatrixToString(List<List<int>> matrix)
        {
            var output = new StringBuilder();
            var width = matrix
                .Max(line => line.Max())
                .ToString()
                .Length + 1;
            
            output.Append(' ');
            for (var i = 0; i < matrix.Count + 1; i++)
            {
                output.Append(string.Format($"{{0, {width}}}", (i != 0) ? $"{i}" : "|"));
            }

            var outputOldLength = output.Length;
            output.Append('\n');
            for (var i = 0; i < outputOldLength; i++)
            {
                output.Append((i == width) ? "+" : "-");
            }

            output.Append('\n');
            for (var i = 0; i < matrix.Count; i++)
            {
                output.Append(string.Format($"{{0, {width + 1}}}", $"{i + 1} |"));
                foreach (var value in matrix[i])
                {
                    output.Append(string.Format($"{{0, {width}}}", (value == int.MaxValue) ? "M" : value.ToString()));
                }
                output.Append('\n');
            }

            return output.ToString();
        }
    }
}