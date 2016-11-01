using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;

namespace ProjectEuler.Problems
{
	// Solved via a ternary tree. See https://en.wikipedia.org/wiki/Tree_of_primitive_Pythagorean_triples
	public static class Problem75
	{
		private const int LIMIT = 1500000;
		
		private static readonly int[,] MatrixA = { {1, -2, 2}, 
												   {2, -1, 2}, 
												   {2, -2, 3} };

		private static readonly int[,] MatrixB = { {1, 2, 2}, 
												   {2, 1, 2}, 
												   {2, 2, 3} };

		private static readonly int[,] MatrixC = { {-1, 2, 2}, 
												   {-2, 1, 2}, 
												   {-2, 2, 3} };

		public static string Solve()
		{
			Dictionary<int, bool> singularPerimeterMap = new Dictionary<int, bool>();
			int[] startingTriple = new int[] { 3, 4, 5 };
			AddPerimeterToMap(startingTriple.Perimeter(), singularPerimeterMap);
			GenerateNonPrimitiveChildren(startingTriple, singularPerimeterMap);
			PythagoreanTripleHelper(singularPerimeterMap, startingTriple);

			List<KeyValuePair<int, bool>> singularIntegerRightTrianglePerimeters = singularPerimeterMap.Where(kvp => kvp.Value).ToList();
			return singularIntegerRightTrianglePerimeters.Count.ToString();
		}

		private static void PythagoreanTripleHelper(Dictionary<int, bool> singularPerimeterMap, int[] parentTriple)
		{
			// Matrix A
			int[] primitiveChildA = GeneratePrimitiveChildTriple(MatrixA, parentTriple);
			int aPerimeter = primitiveChildA.Perimeter();
			if (aPerimeter <= LIMIT)
			{
				AddPerimeterToMap(aPerimeter, singularPerimeterMap);
				GenerateNonPrimitiveChildren(primitiveChildA, singularPerimeterMap);
				PythagoreanTripleHelper(singularPerimeterMap, primitiveChildA);
			}

			// Matrix B
			int[] primitiveChildB = GeneratePrimitiveChildTriple(MatrixB, parentTriple);
			int bPerimeter = primitiveChildB.Perimeter();
			if (bPerimeter <= LIMIT)
			{
				AddPerimeterToMap(bPerimeter, singularPerimeterMap);
				GenerateNonPrimitiveChildren(primitiveChildB, singularPerimeterMap);
				PythagoreanTripleHelper(singularPerimeterMap, primitiveChildB);
			}

			// Matrix C
			int[] primitiveChildC = GeneratePrimitiveChildTriple(MatrixC, parentTriple);
			int cPerimeter = primitiveChildC.Perimeter();
			if (cPerimeter <= LIMIT)
			{
				AddPerimeterToMap(cPerimeter, singularPerimeterMap);
				GenerateNonPrimitiveChildren(primitiveChildC, singularPerimeterMap);
				PythagoreanTripleHelper(singularPerimeterMap, primitiveChildC);
			}
		}

		private static int[] GeneratePrimitiveChildTriple(int[,] specialMatrix, int[] parentTriple)
		{
			int[] childTriple = new int[3];
			for (int i = 0; i < 3; i++)
			{
				int side = 0;
				for (int j = 0; j < 3; j++)
				{
					side += specialMatrix[i, j] * parentTriple[j];
				}
				childTriple[i] = side;
			}
			return childTriple;
		}

		private static void GenerateNonPrimitiveChildren(int[] triple, Dictionary<int, bool> singularPerimeterMap)
		{
			int[] nonPrimitiveChild = new int[3];
			int perimeter;
			int multFactor = 2;
			do
			{
				nonPrimitiveChild = new int[3];
				nonPrimitiveChild[0] = triple[0] * multFactor;
				nonPrimitiveChild[1] = triple[1] * multFactor;
				nonPrimitiveChild[2] = triple[2] * multFactor;
				perimeter = nonPrimitiveChild.Perimeter();
				if (perimeter <= LIMIT)
				{
					AddPerimeterToMap(perimeter, singularPerimeterMap);
					multFactor++;
				}
			}
			while (perimeter <= LIMIT);
		}

		private static void AddPerimeterToMap(int perimeter, Dictionary<int, bool> singularPerimeterMap)
		{
			if (!singularPerimeterMap.ContainsKey(perimeter))
			{
				singularPerimeterMap.Add(perimeter, true);
			}
			else
			{
				singularPerimeterMap[perimeter] = false;
			}
		}

		public static int Perimeter(this int[] sides)
		{
			return sides[0] + sides[1] + sides[2];
		}
	}
}
