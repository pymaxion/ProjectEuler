using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem81
    {
        public static readonly string matrixFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p081_matrix.txt";

        public static string Solve()
        {
            var lines = FileUtils.ReadFileIntoList(matrixFilepath).ToArray();
            int[,] matrix = new int[lines.Length, lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var nums = lines[i].Split(',');
                for (int j = 0; j < nums.Length; j++)
                {
                    matrix[i, j] = Int32.Parse(nums[j]);
                }
            }

            int[,] minPathSum = new int[lines.Length + 1, lines.Length + 1];
            for (int i = 0; i <= lines.Length; i++)
            {
                minPathSum[i, 0] = Int32.MaxValue;
            }
            for (int i = 0; i <= lines.Length; i++)
            {
                minPathSum[0, i] = Int32.MaxValue;
            }
            minPathSum[0, 1] = 0;
            minPathSum[1, 0] = 0;

            for (int i = 1; i <= lines.Length; i++)
            {
                for (int j = 1; j <= lines.Length; j++)
                {
                    minPathSum[i, j] = matrix[i - 1, j - 1] + Math.Min(minPathSum[i - 1, j], minPathSum[i, j - 1]); // Dynamic Programming Recurrence
                }
            }

            return minPathSum[lines.Length, lines.Length].ToString();
        }
    }
}
