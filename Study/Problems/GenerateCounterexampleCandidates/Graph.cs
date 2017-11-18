using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCounterexampleCandidates
{
    public class Graph
    {
        public List<Vertex> Vertices = new List<Vertex>();

        public IEnumerable<Vertex> Specials
        {
            get { return Vertices.Where(v => v.IAmSpecial); }
        }

        public IEnumerable<int> Degrees
        {
            get { return Vertices.Select(v => v.Neighbors.Count); }
        }

        public Graph()
        {
        }

        public Graph(IList<int> edgeWeights)
            : this()
        {
            var n = (int)((1 + Math.Sqrt(1 + 8 * edgeWeights.Count)) / 2);
            Vertices.AddRange(Enumerable.Range(0, n).Select(i => new Vertex()));

            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (edgeWeights[k] != 0)
                    {
                        Vertices[i].Neighbors.Add(Vertices[j]);
                        Vertices[j].Neighbors.Add(Vertices[i]);
                    }

                    k++;
                }
            }
        }

        public Vertex AddVertex(params Vertex[] neighbors)
        {
            return AddVertex((IEnumerable<Vertex>)neighbors);
        }

        public Vertex AddVertex(IEnumerable<Vertex> neighbors)
        {
            var x = new Vertex();
            foreach (var v in neighbors)
            {
                x.Neighbors.Add(v);
                v.Neighbors.Add(x);
            }
            Vertices.Add(x);

            return x;
        }

        public void AddEdge(Vertex a, Vertex b)
        {
            a.Neighbors.Add(b);
            b.Neighbors.Add(a);
        }

        public void RemoveEdge(Vertex a, Vertex b)
        {
            a.Neighbors.Remove(b);
            b.Neighbors.Remove(a);
        }

        public List<int> GetEdgeWeights()
        {
            var n = Vertices.Count;
            var w = new List<int>(n * (n - 1) / 2);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (Vertices[i].Neighbors.Contains(Vertices[j]))
                        w.Add(1);
                    else
                        w.Add(0);
                }
            }

            return w;
        }

        #region Bron Kerbosch

        public int IndependenceNumber()
        {
            return IndependenceNumber(Enumerable.Range(0, Vertices.Count));
        }
        int IndependenceNumber(IEnumerable<int> subgraph)
        {
            return EnumerateMaximalIndependentSets(subgraph.ToList()).Max(s => s.Count);
        }
        public int CliqueNumber()
        {
            return CliqueNumber(Enumerable.Range(0, Vertices.Count));
        }
        int CliqueNumber(IEnumerable<int> subgraph)
        {
            return EnumerateMaximalCliques(subgraph.ToList()).Max(s => s.Count);
        }
        IEnumerable<List<int>> EnumerateMaximalIndependentSets(List<int> set)
        {
            return EnumerateBronKerbosch(set, new List<int>(), new List<int>(), Vertices.Select(v => Vertices.Except(new[] { v }).Except(v.Neighbors).Select(w => Vertices.IndexOf(w)).ToList()).ToList());
        }
        IEnumerable<List<int>> EnumerateMaximalIndependentSets()
        {
            return EnumerateMaximalIndependentSets(Enumerable.Range(0, Vertices.Count).ToList());
        }
        IEnumerable<List<int>> EnumerateMaximalCliques(List<int> set)
        {
            return EnumerateBronKerbosch(set, new List<int>(), new List<int>(), Vertices.Select(v => v.Neighbors.Select(w => Vertices.IndexOf(w)).ToList()).ToList());
        }
        IEnumerable<List<int>> EnumerateMaximalCliques()
        {
            return EnumerateMaximalCliques(Enumerable.Range(0, Vertices.Count).ToList());
        }
        static IEnumerable<List<int>> EnumerateBronKerbosch(List<int> P, List<int> R, List<int> X, List<List<int>> complementNeighbors)
        {
            if (P.Count == 0 && X.Count == 0)
                yield return R.ToList();
            else
            {
                var PC = P.ToList();
                var XC = X.ToList();

                var u = TomitaPivot(P, X, complementNeighbors);
                foreach (var v in P.Except(complementNeighbors[u]))
                {
                    R.Add(v);
                    foreach (var set in EnumerateBronKerbosch(PC.Intersect(complementNeighbors[v]).ToList(), R, XC.Intersect(complementNeighbors[v]).ToList(), complementNeighbors))
                        yield return set;

                    R.Remove(v);
                    PC.Remove(v);
                    XC.Add(v);
                }
            }
        }
        static int TomitaPivot(List<int> P, List<int> X, List<List<int>> complementNeighbors)
        {
            var max = -1;
            var best = -1;
            foreach (var u in P.Concat(X))
            {
                var n = complementNeighbors[u].Intersect(P).Count();
                if (n > max)
                {
                    max = n;
                    best = u;
                }
            }

            return best;
        }
        #endregion
    }
}
