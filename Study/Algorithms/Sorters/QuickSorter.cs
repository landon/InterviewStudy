using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class QuickSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            Sort(items, 0, items.Length - 1);
        }

        static void Sort(T[] items, int first, int last)
        {
            if (first >= last)
                return;
            var pivotIndex = Partition(items, first, last);
            Sort(items, first, pivotIndex - 1);
            Sort(items, pivotIndex + 1, last);
        }

        static int Partition(T[] items, int first, int last)
        {
            var pivotIndex = first;
            for (int i = first; i < last; i++)
            {
                if (items[i].CompareTo(items[last]) < 0)
                    Swap(items, i, pivotIndex++);
            }
            Swap(items, last, pivotIndex);
            return pivotIndex;
        }
    }
}
