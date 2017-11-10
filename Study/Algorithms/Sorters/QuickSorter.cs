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


        }
    }
}
