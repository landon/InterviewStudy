using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCounterexampleCandidates
{
    public class Vertex
    {
        public bool IAmSpecial;
        public HashSet<Vertex> Neighbors = new HashSet<Vertex>();
    }
}
