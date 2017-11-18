using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Solution
{
     const string C = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
     const string L = "abcdefghijklmnopqrstuvwxyz";

    static void Main(String[] args)
    {
        var count = 1;// int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
            PrintPythag(721);

        Console.ReadKey();
    }

    static void PrintPythag(int n)
    {
        Console.WriteLine(string.Join(" ", Enumerable.Range(0, n + 1).Select(r => Choice(n, r))));
    }

    static Dictionary<Tuple<int, int>, long> Lookup = new Dictionary<Tuple<int, int>, long>();
    static long Choice(int n, int r)
    {
        if (r < 0)
            return 0;
        if (r > n - r)
            r = n - r;
        if (r == 0 || n <= 1)
            return 1;

        var t = new Tuple<int, int>(n, r);
        long value;
        if (!Lookup.TryGetValue(t, out value))
        {
            value = Choice(n - 1, r - 1) + Choice(n - 1, r);
            Lookup[t] = value;
        }

        return value;
    }
}

