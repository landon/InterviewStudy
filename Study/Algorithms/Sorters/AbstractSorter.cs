using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public abstract class AbstractSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public abstract void Sort(T[] items);

        protected static void Swap(T[] items, int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        protected static T FindMin(T[] items, int first, int last, out int index)
        {
            if (items.Length <= last)
            {
                index = -1;
                return default(T);
            }

            index = first;
            var min = items[index];
            for (int i = first + 1; i <= last; i++)
            {
                if (items[i].CompareTo(min) < 0)
                {
                    min = items[i];
                    index = i;
                }
            }

            return min;
        }
    }
}
