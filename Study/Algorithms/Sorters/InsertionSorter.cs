using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class InsertionSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                var j = i;
                while (j >= 1 && items[j - 1].CompareTo(items[j]) > 0)
                {
                    Swap(items, j - 1, j);
                    j--;
                }
            }
        }
    }
}
