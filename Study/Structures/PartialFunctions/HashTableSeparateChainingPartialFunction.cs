using System;

namespace Study.Structures.PartialFunctions
{
    public class HashTableSeparateChainingPartialFunction<TDomain, TCodomain> : IPartialFunction<TDomain, TCodomain>
    {
        int count;
        LinkedList<Tuple<TDomain, TCodomain>>[] _data = new LinkedList<Tuple<TDomain, TCodomain>>[5];

        int GetHash(TDomain x)
        {
            return (int)(((uint)x.GetHashCode()) % _data.Length);
        }

        public void Add(TDomain x, TCodomain y)
        {
            var h = GetHash(x);
            if (_data[h] == null)
                _data[h] = new LinkedList<Tuple<TDomain, TCodomain>>();
            if (!_data[h].RemoveFirstWhere(tup => tup.Item1.Equals(x)))
                count++;
            _data[h].Prepend(new Tuple<TDomain, TCodomain>(x, y));
        }

        public void Remove(TDomain x)
        {
            var h = GetHash(x);
            if (_data[h] == null)
                return;
            if (_data[h].RemoveFirstWhere(tup => tup.Item1.Equals(x)))
                count--;
        }

        public bool TryApply(TDomain x, out TCodomain y)
        {
            y = default(TCodomain);
            var h = GetHash(x);
            if (_data[h] == null)
                return false;

            Tuple<TDomain, TCodomain> tuple;
            var found = _data[h].TryFindWhere(tup => tup.Item1.Equals(x), out tuple);
            if (found)
                y = tuple.Item2;
            return found;
        }

        public int Count()
        {
            return count;
        }
    }
}
