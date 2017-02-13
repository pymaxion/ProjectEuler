using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectEuler.Utils
{
	public static class TriangleUtils
	{
		public static bool IsTriangleInequalitySatisfied(int a, int b, int c) 
		{
			return (c < a + b);
		}

		public static bool IsRightTriangle(int a, int b, int c)
		{
			return (a * a) + (b * b) == (c * c);
		}

        public static bool IsRightTriangle(double a, double b, double c)
        {
            double lhs = (a * a) + (b * b);
            double rhs = (c * c);
            return Math.Abs(lhs - rhs) <= 0.00001; // since doubles, need tolerance
        }

        public static bool IsRightTriangle(Point a, Point b, Point c)
        {
            double[] sides = new double[3];
            sides[0] = MiscUtils.DistanceFormula(a, b);
            sides[1] = MiscUtils.DistanceFormula(b, c);
            sides[2] = MiscUtils.DistanceFormula(a, c);
            double hypotenuse = sides.Max();
            IEnumerable<double> nonHypotenuse = sides.Where(s => s != hypotenuse);
            return IsRightTriangle(nonHypotenuse.First(), nonHypotenuse.Last(), hypotenuse);
        }
	}
}
