using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        public static void Main()
        {
            var dd = DecodeString("3[a]2[bc]");
            Console.WriteLine(dd);
            Console.ReadKey();
        }

        public static string DecodeString(string s)
        {
            var lastUp = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '[')
                    lastUp = i;
                if (s[i] == ']')
                {
                    int j = lastUp - 1;
                    while (j >= 0 && char.IsDigit(s[j]))
                        j--;
                    j++;
                    var count = int.Parse(s.Substring(j, lastUp - j));
                    var q = s.Substring(lastUp + 1, i - 1 - lastUp);
                    var x = "";
                    for (int w = 0; w < count; w++)
                        x += q;
                    return DecodeString(s.Substring(0, j) + x + s.Substring(i + 1));
                }
            }

            return s;
        }
    }
}
