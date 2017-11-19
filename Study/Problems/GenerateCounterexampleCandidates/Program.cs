using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCounterexampleCandidates
{
    class Program
    {
        const int Delta = 8;

        static void Main(string[] args)
        {
            int total = 0;
            var da = new List<int>() { 2, 2, 2, 2, 2, 2 };
            foreach (var good in EnumerateGraphsWithClassSizes(da).Select(x => { total++;  return x; }).Where(f => f.Degrees.Min() >= Delta - 1)
                .Where(f =>
                {
                    return true;
                })
                .Where(f =>
                {
                    for (int qq = 0; qq < 50; qq++)
                    {
                        if (f.GreedyColor() < Delta)
                            return false;
                    }
                    return f.ChromaticNumber() == Delta;
                })
                .Where(f => f.CliqueNumber() <= Delta - 1).Select(f => f.ToGraph6()))
                Console.Write(good + "  ");
            Console.WriteLine();
            Console.WriteLine("done " + total);
            Console.ReadKey();
        }

        static IEnumerable<Graph> EnumerateGraphsWithClassSizes(IList<int> sizes)
        {
            var degrees = sizes.Select(s => 2*(s - 1));
            var frames = AllGraphsWithDegreeSequenceAtMost(degrees, sizes.Count); // new[] { new Graph("E_`G".GetEdgeWeights()) };
            var completions = frames.SelectMany(f => Explode(f, sizes));
            var missingSomeEdges = completions.SelectMany(f =>
            {
                var a = f.AddVertex();
                a.IAmSpecial = true;
                var b = f.AddVertex();
                b.IAmSpecial = true;
                f.AddVertex(f.Specials);

                return f.Vertices.IndicesWhere(v => v.Degree < Delta).GroupBy(i => f.Vertices[i].Color).Select(g => g.ToList()).CartesianProduct().SelectMany(S =>
                {
                    var f2 = f.Clone();
                    var first = f2.Vertices.Reverse<Vertex>().Skip(1).First();
                    foreach (var i in S)
                        f2.AddEdge(first, f2.Vertices[i]);

                    return f2.Vertices.IndicesWhere(v => v.Degree < Delta).GroupBy(i => f.Vertices[i].Color).Select(g => g.ToList()).CartesianProduct().Select(T =>
                    {
                        var f3 = f2.Clone();
                        var second = f3.Vertices.Reverse<Vertex>().Skip(2).First();
                        foreach (var i in T)
                            f3.AddEdge(second, f3.Vertices[i]);
                        return f3;
                    });
                });
            });
            var rng = new Random();
            var fill = missingSomeEdges.SelectMany(f =>
            {
                return Enumerable.Range(0, 10).Select(iii =>
                {
                    var f2 = f.Clone();
                    var a = Enumerable.Range(0, f2.Vertices.Count).Where(p => f2.Vertices[p].Degree < Delta).ToList();
                    var fails = 0;
                    while (fails < 20)
                    {
                        var ii = rng.Next(a.Count);
                        var jj = rng.Next(a.Count);
                        if (ii == jj || f2.Vertices[a[ii]].Neighbors.Contains(f2.Vertices[a[jj]]))
                        {
                            fails++;
                        }
                        else
                        {
                            fails = 0;
                            f2.AddEdge(f2.Vertices[a[ii]], f2.Vertices[a[jj]]);
                            a = Enumerable.Range(0, f2.Vertices.Count).Where(p => f2.Vertices[p].Degree < Delta).ToList();
                        }
                    }
                    return f2;
                });
            });
            return fill;
        }

        static IEnumerable<Graph> Explode(Graph f, IList<int> sizes)
        {
            var n = f.Vertices.Count;
            var cc = 1;
            foreach (var v in f.Vertices)
            {
                v.IAmSpecial = true;
                v.Color = cc;
                cc++;
            }

            var nv = sizes.Select((s,c) => Enumerable.Range(0, s - 1).Select(i => { var v = f.AddVertex(); v.Color = c + 1; return v; }).ToList()).ToList();
            var roots = f.Specials.ToList();
            
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (f.Vertices[i].Neighbors.Contains(f.Vertices[j]))
                    {
                        f.AddEdge(roots[i], nv[j][0]);
                        f.AddEdge(nv[j][0], nv[i][0]);
                        f.AddEdge(nv[i][0], roots[j]);
                        f.RemoveEdge(roots[i], roots[j]);
                    }
                    else
                    {
                        f.AddEdge(roots[i], roots[j]);
                    }
                }
            }

            yield return f;
        }

        static IEnumerable<Graph> AllGraphsWithDegreeSequenceAtMost(IEnumerable<int> degrees, int n)
        {
            return EnumerateAllGraphs(n).Where(f => IsAtMost(f.Degrees, degrees)).OrderByDescending(f => f.Degrees.Sum());
        }

        static bool IsAtMost(IEnumerable<int> a, IEnumerable<int> b)
        {
            return a.Zip(b, (x, y) => x <= y).All(bb => bb);
        }

        static IEnumerable<Graph> EnumerateAllGraphs(int n)
        {
            return @"C:\Users\landon\Documents\GitHub\InterviewStudy\Study\Problems\GenerateCounterexampleCandidates\graph6.g6".EnumerateGraph6File();
        }
    }
}
