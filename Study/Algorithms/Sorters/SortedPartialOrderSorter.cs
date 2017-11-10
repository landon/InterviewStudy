using Study.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms.Sorters
{
    public class SortedPartialOrderSorter<T, TSortedPartialOrder> : AbstractSorter<T>
        where T : IComparable<T>
        where TSortedPartialOrder : ISortedPartialFunction<T, int>, new()
    {
        public override void Sort(T[] items)
        {
            var partialOrder = new TSortedPartialOrder();
            foreach (var item in items)
            {
                int y;
                if (!partialOrder.TryApply(item, out y))
                    y = 0;
                partialOrder.Add(item, y + 1);
            }
            int i = 0;
            foreach (var x in partialOrder.EnumerateSorted())
            {
                for (int j = 0; j < x.Item2; j++)
                    items[i++] = x.Item1;
            }
        }
    }
}
