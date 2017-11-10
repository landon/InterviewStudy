using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class MergeSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            Sort(items, 0, items.Length - 1, new T[items.Length]);
        }

        static void Sort(T[] items, int first, int last, T[] scratch)
        {
            if (first >= last)
                return;

            var middle = (first + last) / 2;
            Sort(items, first, middle, scratch);
            Sort(items, middle + 1, last, scratch);
            Merge(items, first, middle, last, scratch);
        }

        static void Merge(T[] items, int first, int middle, int last, T[] scratch)
        {
            int i = first;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= last)
            {
                if (items[i].CompareTo(items[j]) <= 0)
                {
                    scratch[k++] = items[i];
                    i++;
                }
                else if (items[i].CompareTo(items[j]) > 0)
                {
                    scratch[k++] = items[j];
                    j++;
                }
            }

            while (i <= middle)
                scratch[k++] = items[i++];
            while (j <= last)
                scratch[k++] = items[j++];

            for (int l = 0; l < k; l++)
                items[first + l] = scratch[l];
        }
    }
}
