using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
    public static class Problem5
    {
        public static string Solve()
        {
            int[] divisors = { 3, 6, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19 };

            long num = 20;
            while (true)
            {
                bool evenlyDivided = true;
                foreach (int divisor in divisors)
                {
                    if (num % divisor != 0)
                    {
                        evenlyDivided = false;
                        break;
                    }
                }

                if (evenlyDivided)
                {
                    return num.ToString();
                }

                num += 20;
            }
        }
    }
}
