using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem44
	{
		public static string Solve()
		{
			List<long> dValues = new List<long>();
			long[] pentagonalNumbersList = SequenceUtils.GenerateFirstNPentagonNumbers(3000L).ToArray();
			HashSet<long> pentagonalNumbers = new HashSet<long>(pentagonalNumbersList);

			HashSet<Tuple<long, long>> candidateNums = new HashSet<Tuple<long, long>>();
			for (int i = 1; i < pentagonalNumbersList.Length; i++)
			{
				long pNum = pentagonalNumbersList[i];
				int upperIndex = Math.Min(SequenceUtils.GetIndexOfFirstPentagonalNumberWithNextDistGreaterThanX(pNum), pentagonalNumbersList.Length - 1);

				for (int j = i + 1; j <= upperIndex; j++)
				{
					long term1 = pentagonalNumbersList[i];
					long term2 = pentagonalNumbersList[j];
					if (pentagonalNumbers.Contains(term1 + term2) && pentagonalNumbers.Contains(term2 - term1))
					{
						candidateNums.Add(new Tuple<long, long>(term1, term2));
					}
				} 
			}

			foreach (Tuple<long, long> candidates in candidateNums)
			{
				dValues.Add(candidates.Item2 - candidates.Item1);
			}

			return dValues.Min().ToString();
		}
	}
}
