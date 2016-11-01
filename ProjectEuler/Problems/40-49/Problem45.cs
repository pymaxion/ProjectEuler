using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem45
	{
		public const long Limit = 10000000000L;

		public static string Solve()
		{
			//HashSet<long> triangularNums = new HashSet<long>(SequenceUtils.GenerateTriangleNumbersLessThanNLong(Limit).Skip(1));
			HashSet<long> pentagonalNums = new HashSet<long>(SequenceUtils.GeneratePentagonNumbersLessThanNLong(Limit).Skip(1));
			HashSet<long> hexagonalNums = new HashSet<long>(SequenceUtils.GenerateHexagonNumbersLessThanNLong(Limit).Skip(1));

			var tripleNums = hexagonalNums.Where(hNum => pentagonalNums.Contains(hNum) /*&& triangularNums.Contains(hNum)*/);

			return tripleNums.ToArray()[1].ToString();
		}
	}
}
