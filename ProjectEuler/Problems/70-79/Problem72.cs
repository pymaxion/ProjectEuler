using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem72
	{
		private const int MAX_D = 1000000;

		public static string Solve()
		{
			long count = 0;

			for (int d = 2; d <= MAX_D; d++)
			{
				count += MiscUtils.EulerTotient(d);
			}

			return count.ToString();
		}
	}
}
