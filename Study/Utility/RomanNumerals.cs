using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Utility
{
    public static class RomanNumerals
    {
        static Dictionary<char, int> A = new Dictionary<char, int>()
        {
            { 'M', 1000 },
            { 'D', 500 },
            { 'C', 100 },
            { 'L', 50 },
            { 'X', 10 },
            { 'V', 5 },
            { 'I', 1 },
        };
        public static string ToRoman(int x)
        {
            if (x <= 0)
                return "";
            if (x >= 1000)
                return "M" + ToRoman(x - 1000);
            if (x >= 500)
                return "D" + ToRoman(x - 500);
            if (x == 400)
                return "CD" + ToRoman(x - 400);
            if (x >= 100)
                return "C" + ToRoman(x - 100);
            if (x == 90)
                return "XC" + ToRoman(x - 90);
            if (x >= 50)
                return "L" + ToRoman(x - 50);
            if (x == 40)
                return "XL" + ToRoman(x - 40);
            if (x >= 10)
                return "X" + ToRoman(x - 10);
            if (x == 9)
                return "IX" + ToRoman(x - 9);
            if (x >= 5)
                return "V" + ToRoman(x - 5);
            if (x == 4)
                return "IV" + ToRoman(x - 4);
            return "I" + ToRoman(x - 1);
        }
        
        public static int FromRoman(string r)
        {
            var arabic = 0;

            for (int i = r.Length - 2; i >= -1; i--)
            {
                if (i >= 0 && A[r[i]] < A[r[i + 1]])
                {
                    arabic += A[r[i + 1]] - A[r[i]];
                    i--;
                }
                else
                {
                    arabic += A[r[i + 1]];
                }
            }

            return arabic;
        }
    }
}
