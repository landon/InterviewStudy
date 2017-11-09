using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms
{
    // TODO: make these methods efficient for a real library.
    public static class PrimeNumbers
    {
        public static int FirstPrimeAtLeast(int n)
        {
            while (!IsPrime(n))
                n++;
            return n;
        }

        public static bool IsPrime(int n)
        {
            if (n % 2 == 0)
                return false;
            for (int i = 3; i * i <= n; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }
}
