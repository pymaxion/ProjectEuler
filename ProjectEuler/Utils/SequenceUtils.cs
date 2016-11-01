using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class SequenceUtils
	{
		public static List<int> GenerateFirstNTriangleNumbers(int n)
		{
			List<int> triangleNums = new List<int>();
			for (int i = 1; i <= n; i++)
			{
				triangleNums.Add(GetNthTriangleNumber(i));
			}
			return triangleNums;
		}

		public static List<int> GenerateTriangleNumbersLessThanN(int n)
		{
			List<int> triangleNums = new List<int>();
			triangleNums.Add(0);
			int idx = 1;

			while (triangleNums[idx - 1] < n)
			{
				triangleNums.Add(GetNthTriangleNumber(idx));
				idx++;
			}

			triangleNums.Remove(0);
			return triangleNums;
		}

		public static int GetNthTriangleNumber(int n)
		{
			return (int)((0.5) * n * (n + 1));
		}

		public static List<long> GenerateTriangleNumbersLessThanNLong(long n)
		{
			List<long> triangleNums = new List<long>();
			triangleNums.Add(0);
			int idx = 1;

			while (triangleNums[idx - 1] < n)
			{
				triangleNums.Add(GetNthTriangleNumberLong(idx));
				idx++;
			}

			triangleNums.Remove(0);
			return triangleNums;
		}

		public static long GetNthTriangleNumberLong(long n)
		{
			return (long)((0.5) * n * (n + 1));
		}

		public static List<int> GenerateSquareNumbersLessThanN(int n)
		{
			List<int> squareNums = new List<int>();
			squareNums.Add(0);
			int idx = 1;

			while (squareNums[idx - 1] < n)
			{
				squareNums.Add(idx * idx);
				idx++;
			}

			squareNums.Remove(0);
			return squareNums;
		}

		public static List<int> GenerateFirstNPentagonNumbers(int n)
		{
			List<int> pentagonNums = new List<int>();
			for (int i = 1; i <= n; i++)
			{
				pentagonNums.Add(GetNthPentagonNumber(i));
			}
			return pentagonNums;
		}

		public static List<long> GenerateFirstNPentagonNumbers(long n)
		{
			List<long> pentagonNums = new List<long>();
			for (long i = 1; i <= n; i++)
			{
				pentagonNums.Add(GetNthPentagonNumber(i));
			}
			return pentagonNums;
		}

		public static List<int> GeneratePentagonNumbersLessThanN(int n)
		{
			List<int> pentagonNums = new List<int>();
			pentagonNums.Add(0);
			int idx = 1;

			while (pentagonNums[idx - 1] < n)
			{
				pentagonNums.Add(GetNthPentagonNumber(idx));
				idx++;
			}

			pentagonNums.Remove(0);
			return pentagonNums;
		}

		public static int GetNthPentagonNumber(int n)
		{
			return (int)((0.5) * n * ((3 * n) - 1));
		}

		public static long GetNthPentagonNumber(long n)
		{
			return (long)((0.5) * n * ((3 * n) - 1));
		}

		public static long GetNextPentagonalDifference(long idx)
		{
			return (3 * idx) + 4;
		}

		public static int GetIndexOfFirstPentagonalNumberWithNextDistGreaterThanX(long x)
		{
			return (int)Math.Floor((x - 4) / (double)3) + 1;
		}

		public static int GetIndexOfFirstPentagonalNumberGreaterThanOrEqualToX(long x)
		{
			var roots = QuadraticUtils.SolveQuadratic((double)(3 / 2), (double)(-1 / 2), (double)x).Select(r => (int)Math.Floor(r));
			return roots.Max();
		}

		public static List<long> GeneratePentagonNumbersLessThanNLong(long n)
		{
			List<long> pentagonNums = new List<long>();
			pentagonNums.Add(0);
			int idx = 1;

			while (pentagonNums[idx - 1] < n)
			{
				pentagonNums.Add(GetNthPentagonNumberLong(idx));
				idx++;
			}

			pentagonNums.Remove(0);
			return pentagonNums;
		}

		public static long GetNthPentagonNumberLong(long n)
		{
			return (long)((0.5) * n * ((3 * n) - 1));
		}

		public static List<int> GenerateFirstNHexagonNumbers(int n)
		{
			List<int> hexagonNums = new List<int>();
			for (int i = 1; i <= n; i++)
			{
				hexagonNums.Add(GetNthHexagonNumber(i));
			}
			return hexagonNums;
		}

		public static List<int> GenerateHexagonNumbersLessThanN(int n)
		{
			List<int> hexagonNums = new List<int>();
			hexagonNums.Add(0);
			int idx = 1;

			while (hexagonNums[idx - 1] < n)
			{
				hexagonNums.Add(GetNthHexagonNumber(idx));
				idx++;
			}

			hexagonNums.Remove(0);
			return hexagonNums;
		}

		public static int GetNthHexagonNumber(int n)
		{
			return (int)(n * ((2 * n) - 1));
		}

		public static List<long> GenerateHexagonNumbersLessThanNLong(long n)
		{
			List<long> hexagonNums = new List<long>();
			hexagonNums.Add(0);
			int idx = 1;

			while (hexagonNums[idx - 1] < n)
			{
				hexagonNums.Add(GetNthHexagonNumberLong(idx));
				idx++;
			}

			hexagonNums.Remove(0);
			return hexagonNums;
		}

		public static long GetNthHexagonNumberLong(long n)
		{
			return (long)(n * ((2 * n) - 1));
		}

		public static List<int> GenerateHeptagonNumbersLessThanN(int n)
		{
			List<int> heptagonNums = new List<int>();
			heptagonNums.Add(0);
			int idx = 1;

			while (heptagonNums[idx - 1] < n)
			{
				heptagonNums.Add(GetNthHeptagonNumber(idx));
				idx++;
			}

			heptagonNums.Remove(0);
			return heptagonNums;
		}

		public static int GetNthHeptagonNumber(int n)
		{
			return (int)(0.5 * n * ((5 * n) - 3));
		}

		public static List<int> GenerateOctagonNumbersLessThanN(int n)
		{
			List<int> octagonNums = new List<int>();
			octagonNums.Add(0);
			int idx = 1;

			while (octagonNums[idx - 1] < n)
			{
				octagonNums.Add(GetNthOctagonNumber(idx));
				idx++;
			}

			octagonNums.Remove(0);
			return octagonNums;
		}

		public static int GetNthOctagonNumber(int n)
		{
			return (int)(n * ((3 * n) - 2));
		}
	}
}
