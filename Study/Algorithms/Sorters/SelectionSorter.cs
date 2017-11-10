using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class SelectionSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                int minIndex;
                FindMin(items, i, items.Length - 1, out minIndex);
                Swap(items, i, minIndex);
            }
        }
    }
}
