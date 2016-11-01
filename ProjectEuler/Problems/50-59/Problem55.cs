using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem55
	{
		public static string Solve()
		{
			List<int> lychrelNums = new List<int>();
			for (int i = 5; i < 10000; i++)
			{
				bool isLychrelNumber = true;
				BigInteger num = (BigInteger)i;
				for (int j = 0; j < 50; j++) 
				{ 
					BigInteger reverseNum = BigInteger.Parse(StringUtils.Reverse(num.ToString()));
					BigInteger sum = num + reverseNum;
					if (StringUtils.IsPalindrome(sum.ToString())) 
					{
						isLychrelNumber = false;
						break;
					}
					else
					{
						num = sum;
					}
				}
				if (isLychrelNumber)
				{
					lychrelNums.Add(i);
				}
			}
			return lychrelNums.Count.ToString();
		}
	}
}
