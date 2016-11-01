using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    //----- http://stackoverflow.com/questions/17927602/how-many-subrectangle-exists-on-a-m-x-n-grid -----//
    public static class Problem85
    {
        private const int StartLen = 10;
        private const int Target = 2000000;

        public static string Solve()
        {
            int closestW = 0;
            int closestH = 0;
            int closestArea = Int32.MaxValue;
            int closestSubRectCount = 0;

            bool outerQuits = false;
            for (int w = StartLen; !outerQuits; w++)
            {
                bool innerQuits = false;
                for (int h = StartLen; !innerQuits; h++)
                {
                    int thisCount = GetSubrectangleCount(w, h);
                    if (Math.Abs(thisCount - Target) < Math.Abs(closestSubRectCount - Target))
                    {
                        closestW = w;
                        closestH = h;
                        closestArea = w * h;
                        closestSubRectCount = thisCount;
                    }

                    innerQuits = thisCount > Target;
                }

                outerQuits = GetSubrectangleCount((w + 1), StartLen) > Target;
            }

            return closestArea.ToString();
        }

        public static int GetSubrectangleCount(int width, int height) 
        {
            return (width * (width + 1) * height * (height + 1)) / 4;
        }
    }
}
