using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem78
	{
		private const long LIMIT = (long)6e4;
		
		public static string Solve()
		{
			Dictionary<long, BigInteger> partitionDict = Combinatorics.GetPartitionDictionaryBig(LIMIT);
			long value = partitionDict.FirstOrDefault(kvp => kvp.Value % (BigInteger)1e6 == 0).Key;
			return value.ToString();
		}
	}
}
