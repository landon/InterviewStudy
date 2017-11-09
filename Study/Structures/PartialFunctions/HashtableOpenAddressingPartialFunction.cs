using System;

namespace Study.Structures.PartialFunctions
{
    public class HashtablePartialFunction<TDomain, TCodomain> : IPartialFunction<TDomain, TCodomain>
    {
        int count;
        Tuple<TDomain, TCodomain, bool>[] _data = new Tuple<TDomain, TCodomain, bool>[5];

        public void Add(TDomain x, TCodomain y)
        {
            if (Add(_data, x, y))
            {
                count++;

                if (count >= _data.Length / 2)
                    Grow();
            }
        }

        public void Remove(TDomain x)
        {
            var h = FindPosition(_data, x);
            if (_data[h] != null && !_data[h].Item3)
            {
                _data[h] = new Tuple<TDomain, TCodomain, bool>(_data[h].Item1, _data[h].Item2, true);
                count--;
            }
        }

        public bool TryApply(TDomain x, out TCodomain y)
        {
            y = default(TCodomain);
            var h = FindPosition(_data, x);
            if (_data[h] == null || _data[h].Item3)
                return false;
            if (_data[h].Item1.Equals(x))
                y = _data[h].Item2;
            return true;
        }

        public int Count()
        {
            return count;
        }

        void Grow()
        {
            var size = Algorithms.PrimeNumbers.FirstPrimeAtLeast(2 * _data.Length);
            var data = new Tuple<TDomain, TCodomain, bool>[size];
            var c = 0;

            for (int i = 0; i < _data.Length; i++)
            {
                var tuple = _data[i];
                if (tuple == null || tuple.Item3)
                    continue;

                Add(data, tuple.Item1, tuple.Item2);
                c++;
            }

            _data = data;
            count = c;
        }

        static bool Add(Tuple<TDomain, TCodomain, bool>[] data, TDomain x, TCodomain y)
        {
            var h = FindPosition(data, x);
            var added = data[h] == null;
            data[h] = new Tuple<TDomain, TCodomain, bool>(x, y, false);

            return added;
        }

        static int FindPosition(Tuple<TDomain, TCodomain, bool>[] data, TDomain x)
        {
            var h = GetHash(x, data.Length);

            int i = 0;
            while (true)
            {
                var hh = (h + i * i) % data.Length;
                if (data[hh] == null || data[hh].Item1.Equals(x))
                    return hh;

                i++;
            }
        }

        static int GetHash(TDomain x, int size)
        {
            return (int)(((uint)x.GetHashCode()) % size);
        }
    }
}
