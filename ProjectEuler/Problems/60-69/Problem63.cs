using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using System.Numerics;

namespace ProjectEuler.Problems
{
	public static class Problem63
	{
		public static string Solve()
		{
			//Dictionary<BigInteger, int> powerfulDigits = new Dictionary<BigInteger, int>();
			int count = 0;
			bool canStop = false;

			for (int exponent = 1; !canStop; exponent++)
			{
				for (int baseNum = 1; baseNum < 10; baseNum++)
				{
					BigInteger expNum = BigInteger.Pow(baseNum, exponent);
					if (DigitUtils.GetNumberOfDigits(expNum) == exponent)
					{
						//powerfulDigits.Add(expNum, baseNum);
						count++;
					}
					else if (baseNum == 9)
					{
						canStop = true;
					}
				}
			}

			return count.ToString();
		}
	}
}
