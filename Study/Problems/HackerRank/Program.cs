﻿using System;
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
            var mnr = new int[] { 4, 4, 6 };//Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToList();
            var m = mnr[0];
            var n = mnr[1];
            var r = mnr[2];
            var d = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                var j = 0;
                foreach (var x in Console.ReadLine().Split(' ').Select(x => int.Parse(x)))
                {
                    var tup = Destination(i, j, m, n, r);
                    d[tup.Item1, tup.Item2] = x;
                    j++;
                }
            }
            for (int i = 0; i < m; i++)
                Console.WriteLine(string.Join(" ", Enumerable.Range(0, n).Select(j => d[i, j])));

            Console.ReadKey();
        }

        static Dictionary<Tuple<int, int, int, int>, Tuple<int, int>> _lookup = new Dictionary<Tuple<int, int, int, int>, Tuple<int, int>>();
        static Tuple<int, int> Destination(int i, int j, int m, int n, int r)
        {
            for (int k = 0; k < r; k++)
            {
                var tup = Destination(i, j, m, n);
                i = tup.Item1;
                j = tup.Item2;
            }

            return new Tuple<int, int>(i, j);
        }

        static Tuple<int, int> Destination(int i, int j, int m, int n)
        {
            var key = new Tuple<int, int, int, int>(i, j, m, n);
            Tuple<int, int> answer;
            if (_lookup.TryGetValue(key, out answer))
                return answer;

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

            _lookup[key] = answer;
            return answer;
        }

        static int ToOuterRing(int i, int j, int m, int n)
        {
            return Math.Min(Math.Min(i, j), Math.Min(m - 1 - i, n - 1 - j));
        }
    }
}
