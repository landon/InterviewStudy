using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures
{
    public class Graph
    {
        public int N { get; private set; }
        HashSet<int>[] _neighbors;
        public int[] Coloring { get; private set; }

        public Graph(int n)
        {
            N = n;
            _neighbors = new HashSet<int>[N];
            for (int i = 0; i < N; i++)
                _neighbors[i] = new HashSet<int>();

            Coloring = new int[N];
        }

        public Graph(List<int> edgeWeights)
            : this((int)((1 + Math.Sqrt(1 + 8 * edgeWeights.Count)) / 2))
        {
            int k = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (edgeWeights[k] != 0)
                        AddEdge(i, j);

                    k++;
                }
            }
        }

        public Graph(string graph6)
            : this(GetEdgeWeights(graph6))
        {
        }

        #region graph6
        static List<int> GetEdgeWeights(string graph6)
        {
            var chars = graph6.ToCharArray();

            var bytes = UTF8Encoding.UTF8.GetBytes(chars);

            var N = bytes[0] - 63;
            var h = N * (N - 1) / 2;
            var w = bytes.Skip(1).SelectMany(b => Low6((byte)(b - 63))).Take(h).ToList();

            var p = RowToColumnPermutation(N).ToList();
            var wp = new List<int>(h);

            for (int i = 0; i < p.Count; i++)
                wp.Add(w[p[i]]);

            return wp;
        }

        static IEnumerable<int> RowToColumnPermutation(int n)
        {
            var x = 0;
            for (int j = 0; j < n - 1; j++)
            {
                var y = x;
                for (int i = 0; i < n - 1 - j; i++)
                {
                    yield return y;

                    y += 1 + j + i;
                }

                x += 2 + j;
            }
        }

        static IEnumerable<int> Low6(byte b)
        {
            for (int i = 5; i >= 0; i--)
                yield return (b & (1 << i)) >> i;
        }
        #endregion

        public void AddEdge(int i, int j)
        {
            _neighbors[i].Add(j);
            _neighbors[j].Add(i);
        }

        public void RemoveEdge(int i, int j)
        {
            _neighbors[i].Remove(j);
            _neighbors[j].Remove(i);
        }

        public List<int> TwoColorOrFindOddCycle()
        {
            var seen = new bool[N];
            var parent = new int[N];
            seen[0] = true;
            Coloring[0] = 1;
            parent[0] = -1;

            var Q = new Queue<int>();
            Q.Enqueue(0);
            while (Q.Count > 0)
            {
                var v = Q.Dequeue();
                foreach (var w in _neighbors[v])
                {
                    if (seen[w])
                    {
                        if (Coloring[w] != 3 - Coloring[v])
                        {
                            var x = v;
                            var vToRoot = new List<int>();
                            while (x >= 0)
                            {
                                vToRoot.Add(x);
                                x = parent[x];
                            }

                            vToRoot.Reverse();
                            x = w;
                            while (x >= 0)
                            {
                                vToRoot.Add(x);
                                x = parent[x];
                            }

                            return vToRoot;
                        }
                    }
                    else
                    {
                        seen[w] = true;
                        Coloring[w] = 3 - Coloring[v];
                        parent[w] = v;
                        Q.Enqueue(w);
                    }
                }
            }

            return null;
        }
    }
}
