using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class BubbleSorter<T> : AbstractSorter<T>
        where T : IComparable<T>
    {
        public override void Sort(T[] items)
        {
            while (true)
            {
                var swapped = false;
                for (int i = 1; i < items.Length; i++)
                {
                    if (items[i - 1].CompareTo(items[i]) > 0)
                    {
                        Swap(items, i - 1, i);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
    }
}
