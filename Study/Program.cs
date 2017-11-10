using Study.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph("Jsa@IchDIS_");
            var cycle = g.TwoColorOrFindOddCycle();
        }
    }
}
