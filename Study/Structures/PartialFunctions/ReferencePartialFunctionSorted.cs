﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures.PartialFunctions
{
    public class ReferencePartialFunctionSorted<TDomain, TCodomain> : ISortedPartialFunction<TDomain, TCodomain>
        where TDomain : IComparable<TDomain>
    {
        SortedDictionary<TDomain, TCodomain> _map = new SortedDictionary<TDomain, TCodomain>();

        public void Add(TDomain x, TCodomain y)
        {
            _map[x] = y;
        }

        public void Remove(TDomain x)
        {
            _map.Remove(x);
        }

        public bool TryApply(TDomain x, out TCodomain y)
        {
            return _map.TryGetValue(x, out y);
        }

        public int Count()
        {
            return _map.Count;
        }

        public System.Collections.Generic.IEnumerable<Tuple<TDomain, TCodomain>> EnumerateSorted()
        {
            return _map.Select(kvp => new Tuple<TDomain, TCodomain>(kvp.Key, kvp.Value));
        }
    }
}
