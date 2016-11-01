using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	public static class Problem39
	{
		public static string Solve()
		{
			int mostTriangles = 0;
			int pWithMostTriangles = 0;

			for (int p = 5; p <= 1000; p++)
			{
				int numTriangles = 0;

				for (int c = 1; c < p; c++)
				{
					for (int b = 1; b < c && b < p - c; b++)
					{
						int a = p - c - b;
						if ((a < b) && (a < c) && TriangleUtils.IsRightTriangle(a, b, c))
						{
							numTriangles++;
						}

					}
				}

				if (numTriangles > mostTriangles)
				{
					mostTriangles = numTriangles;
					pWithMostTriangles = p;
				}
			}

			return pWithMostTriangles.ToString();
		}
	}
}
