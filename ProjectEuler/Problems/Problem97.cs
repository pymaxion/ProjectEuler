using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem97
	{
		private const int Power = 7830457;
		
		public static string Solve()
		{
			long lastTen = 1;
			for (int i = 1; i <= Power; i++)
			{
				lastTen = (lastTen * 2) % (long)1e10;
			}

			lastTen *= 28433;
			lastTen %= (long)1e10;
			lastTen++;

			return lastTen.ToString();
		}
	}
}
