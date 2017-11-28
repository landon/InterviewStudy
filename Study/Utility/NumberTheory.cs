using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Utility
{
    public static class NumberTheory
    {
        public static int GCD(int a, int b)
        {
            return GCDOrdered(Math.Max(a, b), Math.Min(a, b));
        }

        static int GCDOrdered(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        public static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }
    }
}
