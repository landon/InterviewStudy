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
        public int Color;
        public int Degree { get { return Neighbors.Count; } }
        public HashSet<Vertex> Neighbors = new HashSet<Vertex>();
    }
}
