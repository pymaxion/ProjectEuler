using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem99
    {
        public static readonly string baseExpFilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\p099_base_exp.txt";

        public static string Solve()
        {
            string[] baseExpLines = FileUtils.ReadFileIntoList(baseExpFilepath, 1000).ToArray();
            double[] logarithmicVals = new double[baseExpLines.Length];

            for (int i = 0; i < baseExpLines.Length; i++)
            {
                int[] baseAndExp = baseExpLines[i].Split(',').Select(s => Int32.Parse(s)).ToArray();
                int baseNum = baseAndExp[0];
                int exp = baseAndExp[1];

                logarithmicVals[i] = exp * Math.Log((double)baseNum, 10);
            }

            double maxVal = Double.MinValue;
            int idxOfMaxVal = 0;
            for (int i = 0; i < logarithmicVals.Length; i++)
            {
                if (logarithmicVals[i] > maxVal)
                {
                    maxVal = logarithmicVals[i];
                    idxOfMaxVal = i;
                }
            }

            return (idxOfMaxVal + 1).ToString();
        }
    }
}
