using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Utils
{
	public static class QuadraticUtils
	{
		public static double[] SolveQuadratic(double a, double b, double c)
		{
			double[] roots = new double[2];
			double denom = 2 * a;
			roots[0] = (-b + QuadEqSqrt(a, b, c)) / denom;
			roots[1] = (-b - QuadEqSqrt(a, b, c)) / denom;
			return roots;
		}

		private static double QuadEqSqrt(double a, double b, double c)
		{
			return Math.Sqrt((b * b) - (4 * a * c));
		}
	}
}
