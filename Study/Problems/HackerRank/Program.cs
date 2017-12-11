using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static int anagram(string s)
        {
            if (s.Length % 2 == 1)
                return -1;

            var c1 = new Dictionary<char, int>();
            var c2 = new Dictionary<char, int>();

            foreach (var c in s)
            {
                c1[c] = 0;
                c2[c] = 0;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length / 2)
                    c1[s[i]]++;
                else
                    c2[s[i]]++;
            }

            var d = s.Distinct().Select(c => c2[c] - c1[c]).ToList();
            return d.Where(aa => aa > 0).Sum();
        }

        static void Main(String[] args)
        {
            int q = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < q; a0++)
            {
                string s = Console.ReadLine();
                int result = anagram(s);
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }
    }
}
