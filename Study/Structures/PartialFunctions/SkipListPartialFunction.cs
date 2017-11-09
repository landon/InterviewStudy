using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures.PartialFunctions
{
    public class SkipListPartialFunction<TDomain, TCodomain> : ISortedPartialFunction<TDomain, TCodomain>
        where TDomain : IComparable<TDomain>
    {
        Random RNG = new Random(DateTime.Now.Millisecond);
        Entry _topHead, _topTail;
        int _height = 0;
        int _count = 0;

        public SkipListPartialFunction()
        {
            _topHead = new Entry() { IsEnd = true };
            _topTail = new Entry() { IsEnd = true };
            _topHead.Right = _topTail;
            _topTail.Left = _topHead;
        }

        public void Add(TDomain x, TCodomain y)
        {
            var e = Find(x);
            if (x.Equals(e.X))
            {
                e.Y = y;
                return;
            }

            var f = new Entry() { X = x, Y = y };
            f.Left = e;
            f.Right = e.Right;
            e.Right.Left = f;
            e.Right = f;

            var level = 0;
            while (RNG.NextDouble() < 0.5)
            {
                if (level >= _height)
                {
                    var topLeft = new Entry() { IsEnd = true };
                    var topRight = new Entry() { IsEnd = true };
                    topLeft.Right = topRight;
                    topLeft.Down = _topHead;
                    topRight.Left = topLeft;
                    topRight.Down = _topTail;
                    _topHead.Up = topLeft;
                    _topTail.Up = topRight;
                    _topHead = topLeft;
                    _topTail = topRight;
                    _height++;
                }

                while (e.Up == null)
                    e = e.Left;
                e = e.Up;

                var ee = new Entry() { X = x };
                ee.Left = e;
                ee.Right = e.Right;
                ee.Down = f;
                e.Right.Left = ee;
                e.Right = ee;
                f.Up = ee;
                f = ee;

                level++;
            }

            _count++;
        }

        public void Remove(TDomain x)
        {
            var e = Find(x);
            if (!x.Equals(e.X))
                return;

            while (e != null)
            {
                e.Left.Right = e.Right;
                e.Right.Left = e.Left;
                e = e.Up;
            }

            _count--;
        }

        public bool TryApply(TDomain x, out TCodomain y)
        {
            var e = Find(x);
            y = e.Y;
            return x.Equals(e.X);
        }

        public int Count()
        {
            return _count;
        }

        public IEnumerable<Tuple<TDomain, TCodomain>> EnumerateSorted()
        {
            var p = _topHead;
            while (p.Down != null)
                p = p.Down;

            p = p.Right;
            while (!p.IsEnd)
            {
                yield return new Tuple<TDomain, TCodomain>(p.X, p.Y);
                p = p.Right;
            }
        }

        Entry Find(TDomain x)
        {
            var p = _topHead;

            while (true)
            {
                while (!p.Right.IsEnd && p.Right.X.CompareTo(x) <= 0)
                    p = p.Right;

                if (p.Down != null)
                    p = p.Down;
                else
                    break;
            }

            return p;
        }

        class Entry
        {
            public TDomain X;
            public TCodomain Y;
            public Entry Up;
            public Entry Down;
            public Entry Left;
            public Entry Right;
            public bool IsEnd;
        }
    }
}
