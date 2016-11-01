using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem112
	{
		public static string Solve()
		{
			Dictionary<string, int> bouncyDict = new Dictionary<string, int>();
			string numStr;

			// initialize to 100
			for (int i = 0; i < 100; i++)
			{
				numStr = i.ToString();
				bouncyDict.Add(numStr, numStr.BouncyType());
			}

			int num = 99;
			int bouncyCount = 0;
			int bouncyType;
			do
			{
				num++;
				numStr = num.ToString();
				if (num == 21780)
				{
					int f = 0;
				}

				int numBaseBouncyType = GetBaseBouncyType(numStr, bouncyDict);
				if (numBaseBouncyType == 2)
				{
					bouncyType = 2;
					bouncyCount++;
				}
				else if (numBaseBouncyType == 1 && numStr[0] >= numStr[1])
				{
					bouncyType = 1;
				}
				else if (numBaseBouncyType == 0 && numStr[0] <= numStr[1])
				{
					bouncyType = 0;
				}
				else
				{
					bouncyType = numStr.BouncyType();
					if (bouncyType == 2)
					{
						bouncyCount++;
					}
				}
				bouncyDict.Add(numStr, bouncyType);
			} 
			while ((double)bouncyCount / (double)num != 0.99);

			return num.ToString();
		}

		public static int BouncyType(this string numStr)
		{
			if (numStr.Length == 1)
			{
				return -1;
			}
			if (String.Equals(new string(numStr.OrderBy(c => c).ToArray()), numStr))
			{
				return 0;
			}
			else if (String.Equals(new string(numStr.OrderByDescending(c => c).ToArray()), numStr))
			{
				return 1;
			}
			return 2;
		}

		private static int GetBaseBouncyType(string numStr, Dictionary<string, int> bouncyDict)
		{
			string baseStr = numStr.Substring(1, numStr.Length - 1);
			if (!bouncyDict.ContainsKey(baseStr))
			{
				bouncyDict.Add(baseStr, baseStr.BouncyType());
			}
			return bouncyDict[baseStr];
		}
	}
}
