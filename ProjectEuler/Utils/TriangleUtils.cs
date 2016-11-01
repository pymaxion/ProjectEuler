using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
