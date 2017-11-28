using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(String[] args)
        {
            var mnr = new int[] { 210, 202, 7865 };//Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var m = mnr[0];
            var n = mnr[1];
            var r = mnr[2];
            var d = new int[m, n];
            var periods = ComputePeriods(m, n);

            for (int i = 0; i < m; i++)
            {
                var j = 0;
                foreach (var x in Console.ReadLine().Split(' ').Select(x => int.Parse(x)))
                {
                    var q = ToOuterRing(i, j, m, n);
                    var p = periods[q];
                    var tup = Destination(i, j, m, n, r % p);
                    d[tup.Item1, tup.Item2] = x;
                    j++;
                }
            }

            for (int i = 0; i < m; i++)
                Console.WriteLine(string.Join(" ", Enumerable.Range(0, n).Select(j => d[i, j])));

            Console.ReadKey();
        }

        static List<int> ComputePeriods(int m, int n)
        {
            var periods = new List<int>();
            for (int k = 0; k <= Math.Min(m, n); k++)
            {
                var p = 2 * (m + n - 4 * k) - 4;
                if (p <= 0)
                    break;
                periods.Add(p);  
            }
            return periods;
        }

        static Tuple<int, int> Destination(int i, int j, int m, int n, int r)
        {
            if (r == 0)
                return new Tuple<int, int>(i, j);
            var tup = Destination(i, j, m, n, r - 1);
            var answer = Destination(tup.Item1, tup.Item2, m, n);

            return answer;
        }

        static Tuple<int, int> Destination(int i, int j, int m, int n)
        {
            Tuple<int, int> answer = null;
            var q = ToOuterRing(i, j, m, n);
            var left = ToOuterRing(i, j - 1, m, n);
            var right = ToOuterRing(i, j + 1, m, n);
            var up = ToOuterRing(i - 1, j, m, n);
            var down = ToOuterRing(i + 1, j, m, n);

            if (up < q)  // on topmost part of our cycle
            {
                if (left == q) // can freely move left, so move left
                    answer = new Tuple<int, int>(i, j - 1);
                else
                    answer = new Tuple<int, int>(i + 1, j); // otherwise must be top left corner, move down
            }
            else if (down < q) // on bottommost part of our cycle
            {
                if (right == q) // can freely move right, so move right
                    answer = new Tuple<int, int>(i, j + 1);
                else
                    answer = new Tuple<int, int>(i - 1, j); // otherwise must be bottom right corner, move up
            }
            else // inside the left or right side
            {
                if (left < q)  // if left, move down
                    answer =  new Tuple<int, int>(i + 1, j);
                else
                    answer = new Tuple<int, int>(i - 1, j); // otherwise in right side, move up
            }

            return answer;
        }

        static int ToOuterRing(int i, int j, int m, int n)
        {
            return Math.Min(Math.Min(i, j), Math.Min(m - 1 - i, n - 1 - j));
        }
    }
}
