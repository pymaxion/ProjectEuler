using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using System.Numerics;

namespace ProjectEuler.Problems
{
	public static class Problem62
	{
		public static string Solve()
		{
			Dictionary<string, List<int>> permutedCubes = new Dictionary<string, List<int>>();
			int cubeBase = 345;
			List<int> smallestCubeBases = new List<int>();
			bool found = false;

			while (!found)
			{
				BigInteger cube = BigInteger.Pow(cubeBase, 3);
				string sortedCubeStr = StringUtils.SortString(cube.ToString());
				if (!permutedCubes.ContainsKey(sortedCubeStr))
				{
					List<int> cubeBases = new List<int>();
					permutedCubes.Add(sortedCubeStr, cubeBases);
				}
				permutedCubes[sortedCubeStr].Add(cubeBase);
				cubeBase++;

				if (permutedCubes[sortedCubeStr].Count == 5)
				{
					smallestCubeBases = permutedCubes[sortedCubeStr];
					found = true;
				}
			}

			return BigInteger.Pow(smallestCubeBases.Min(), 3).ToString();
		}
	}
}
