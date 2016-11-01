using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem52
	{
		public static string Solve()
		{
			long i;
			for (i = (long)1; i < 1e6; i++)
			{
				string sortedDigits = StringUtils.SortString(i.ToString());
				string sortedDigitsOfProduct;
				bool found = true;
				for (long j = 2; j <= 6; j++)
				{
					sortedDigitsOfProduct = StringUtils.SortString((i * j).ToString());
					if (!String.Equals(sortedDigits, sortedDigitsOfProduct))
					{
						found = false;
						break;
					}
				}
				if (found)
				{
					break;
				}
			}
			return i.ToString();
		}
	}
}
