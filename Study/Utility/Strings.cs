using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Utility
{
    public static class Strings
    {
        public static int CountSubstring(string s, string ss)
        {
            var count = 0;
            var i = 0;
            while (i < s.Length)
            {
                i = s.IndexOf(ss, i);
                if (i < 0)
                    return count;
                count++;
                i++;
            }

            return count;
        }

        public static bool IsPalindrome(string s)
        {
            return Enumerable.Range(0, s.Length / 2).All(i => s[i] == s[s.Length - 1 - i]);
        }
    }
}
