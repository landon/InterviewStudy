using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCounterexampleCandidates
{
    class Program
    {
        static void Main(string[] args)
        {
            var da = new List<int>() { 2, 2, 2, 2, 2, 2 };
            var goods = string.Join("  ", EnumerateGraphsWithClassSizes(da).Where(f => f.CliqueNumber() <= 6).Select(f => f.ToGraph6()));
            Console.WriteLine(goods);
            Console.WriteLine();
            Console.WriteLine("done");
            Console.ReadKey();
        }

        static IEnumerable<Graph> EnumerateGraphsWithClassSizes(IList<int> sizes)
        {
            var degrees = sizes.Select(s => 2*(s - 1));
            var frames = AllGraphsWithDegreeSequenceAtMost(degrees, sizes.Count); // new[] { new Graph("E_`G".GetEdgeWeights()) };
            var completions = frames.SelectMany(f => Explode(f, sizes));
            var missingSomeEdges = completions.Select(f =>
            {
                f.AddVertex().IAmSpecial = true;
                f.AddVertex().IAmSpecial = true;
                f.AddVertex(f.Specials);
                return f;
            });

            return missingSomeEdges;
        }

        static IEnumerable<Graph> Explode(Graph f, IList<int> sizes)
        {
            var n = f.Vertices.Count;
            foreach (var v in f.Vertices)
                v.IAmSpecial = true;

            var nv = sizes.Select(s => Enumerable.Range(0, s - 1).Select(i => f.AddVertex()).ToList()).ToList();
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
            return EnumerateAllGraphs(n).Where(f => IsAtMost(f.Degrees, degrees));
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
