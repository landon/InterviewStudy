using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Algorithms
{
    public interface ISorter<T>
        where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
