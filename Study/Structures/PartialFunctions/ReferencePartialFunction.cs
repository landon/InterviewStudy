﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures.PartialFunctions
{
    public class ReferencePartialFunction<TDomain, TCodomain> : IPartialFunction<TDomain, TCodomain>
    {
        Dictionary<TDomain, TCodomain> _map = new Dictionary<TDomain, TCodomain>();

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
    }
}
