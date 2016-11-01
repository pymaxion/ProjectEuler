using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem74
	{
		public static string Solve()
		{
			HashSet<int> numberChain;
			int currNum;
			int chainsOfLength60 = 0;

			for (int i = 1; i < 1e6; i++)
			{
				currNum = i;
				numberChain = new HashSet<int>();
				while (!numberChain.Contains(currNum))
				{
					numberChain.Add(currNum);
					currNum = currNum.Explode();
				}

				if (numberChain.Count == 60)
				{
					chainsOfLength60++;
				}
			}

			return chainsOfLength60.ToString();
		}

		public static int Explode(this int currNum)
		{
			int explodedNum = 0;
			foreach (int digit in DigitUtils.GetDigits(currNum))
			{
				explodedNum += MiscUtils.DigitFactorials[digit];
			}
			return explodedNum;
		}
	}
}
