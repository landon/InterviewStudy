using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCounterexampleCandidates
{
    public class SublistEnumeration
    {
        public static IEnumerable<List<T>> EnumerateSublists<T>(List<T> list)
        {
            int n = list.Count;
            foreach (List<bool> inOut in EnumerateShortLex(n))
                yield return ExtractSublist(list, inOut);
        }

        public static IEnumerable<List<T>> EnumerateSublists<T>(List<T> list, int size)
        {
            int n = list.Count;
            foreach (List<bool> inOut in EnumerateShortLex(n, size))
                yield return ExtractSublist(list, inOut);
        }

        static List<T> NextSublist<T>(List<T> list, int size, ref List<bool> state)
        {
            int n = list.Count;
            bool areMore = NextShortLex(n, size, ref state);

            List<T> sublist = ExtractSublist(list, state);

            if (!areMore)
            {
                state = null;
            }

            return sublist;
        }

        static List<T> ExtractSublist<T>(List<T> list, List<bool> inOut)
        {
            List<T> sublist = new List<T>();
            for (int i = 0; i < inOut.Count; i++)
            {
                if (inOut[i])
                    sublist.Add(list[i]);
            }

            return sublist;
        }

        static IEnumerable<List<bool>> EnumerateShortLex(int n, int k)
        {
            k = Math.Max(0, k);

            List<bool> list = new List<bool>(n);
            for (int i = 0; i < k; i++)
                list.Add(true);
            for (int i = k; i < n; i++)
                list.Add(false);

            do
            {
                yield return list;
            }
            while (NextSameTrueCount(list, k));
        }

        public static IEnumerable<List<bool>> EnumerateShortLex(int n)
        {
            var list = new List<bool>(n);
            for (int i = 0; i < n; i++)
                list.Add(false);

            do
            {
                yield return list;
            }
            while (Next(list));
        }

        static bool NextShortLex(int n, int k, ref List<bool> state)
        {
            if (state == null)
            {
                k = Math.Max(0, k);

                state = new List<bool>(n);
                for (int i = 0; i < k; i++)
                    state.Add(true);
                for (int i = k; i < n; i++)
                    state.Add(false);

                return k > 0 && k < n;
            }

            return NextSameTrueCount(state, k);
        }

        static bool Next(List<bool> list)
        {
            int trueCount = ((IEnumerable<bool>)list).Count(b => b);
            if (trueCount == list.Count)
                return false;

            int firstHole = FindFirstHole(list);

            if (firstHole >= list.Count)
            {
                for (int i = 0; i < trueCount + 1; i++)
                    list[i] = true;
                for (int i = trueCount + 1; i < list.Count; i++)
                    list[i] = false;
            }
            else
            {
                list[firstHole] = true;

                int initialTrues = trueCount;
                for (int i = firstHole; i < list.Count; i++)
                {
                    if (list[i])
                        initialTrues--;
                }

                for (int i = 0; i < initialTrues; i++)
                    list[i] = true;
                for (int i = initialTrues; i < firstHole; i++)
                    list[i] = false;
            }

            return true;
        }

        static bool NextSameTrueCount(List<bool> list, int trueCount)
        {
            int firstHole = FindFirstHole(list);

            if (firstHole >= list.Count)
                return false;

            list[firstHole] = true;

            int initialTrues = trueCount;
            for (int i = firstHole; i < list.Count; i++)
            {
                if (list[i])
                    initialTrues--;
            }

            for (int i = 0; i < initialTrues; i++)
                list[i] = true;
            for (int i = initialTrues; i < firstHole; i++)
                list[i] = false;

            return true;
        }

        static int FindFirstHole(List<bool> list)
        {
            int i = 0;
            while (i < list.Count - 1)
            {
                if (list[i] && !list[i + 1])
                    break;

                i++;
            }

            return i + 1;
        }
    }
}
