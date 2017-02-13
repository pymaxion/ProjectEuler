using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectEuler.Utils;
using System.Drawing;

namespace ProjectEuler.Problems
{
    public static class Problem91
    {
        private const int GridSize = 50;

        public static string Solve()
        {
            long rightTriangleCount = 0;
            var allCoordinates = GenerateAllCoordinates(GridSize);
            Point origin = allCoordinates[0];

            for (int i = 1; i < allCoordinates.Count; i++)
            {
                Point p1 = allCoordinates[i];
                for (int j = i + 1; j < allCoordinates.Count; j++)
                {
                    Point p2 = allCoordinates[j];
                    if (TriangleUtils.IsRightTriangle(origin, p1, p2))
                    {
                        rightTriangleCount++;
                    }
                }
            }

            return rightTriangleCount.ToString();
        }

        public static List<Point> GenerateAllCoordinates(int gridSize)
        {
            List<Point> allCoordinates = new List<Point>();
            for (int i = 0; i <= gridSize; i++)
            {
                for (int j = 0; j <= gridSize; j++)
                {
                    allCoordinates.Add(new Point(i, j));
                }
            }
            return allCoordinates;
        }
    }
}
