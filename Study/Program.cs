using Study.Utility;
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
        for (int i = 1; i < 1001; i++)
        {
            var r = RomanNumerals.ToRoman(i);
            Console.WriteLine(i + " = " + RomanNumerals.FromRoman(r));
        }

        Console.ReadKey();
    }
}

