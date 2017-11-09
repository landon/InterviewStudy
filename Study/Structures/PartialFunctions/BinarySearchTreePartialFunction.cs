using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures.PartialFunctions
{
    public class BinarySearchTreePartialFunction<TDomain, TCodomain> : IPartialFunction<TDomain, TCodomain>
        where TDomain : IComparable<TDomain>
    {
        bool _used;
        TDomain _x;
        TCodomain _y;
        BinarySearchTreePartialFunction<TDomain, TCodomain> _left;
        BinarySearchTreePartialFunction<TDomain, TCodomain> _right;

        public void Add(TDomain x, TCodomain y)
        {
            var bst = Find(x);
            bst._used = true;
            bst._x = x;
            bst._y = y;
        }

        public void Remove(TDomain x)
        {
            var bst = Find(x);
            if (x.Equals(bst._x))
            {
                if (IsEmpty(bst._left) && IsEmpty(bst._right))
                {
                    bst._x = default(TDomain);
                    bst._y = default(TCodomain);
                    bst._used = false;
                }
                else if (IsEmpty(bst._left))
                {
                    var right = bst._right;
                    bst._x = right._x;
                    bst._y = right._y;
                    bst._left = right._left;
                    bst._right = right._right;
                }
                else if (IsEmpty(bst._right))
                {
                    var left = bst._left;
                    bst._x = left._x;
                    bst._y = left._y;
                    bst._left = left._left;
                    bst._right = left._right;
                }
                else
                {
                    var min = FindMin(bst._right);
                    bst._x = min._x;
                    bst._y = min._y;
                    bst._right.Remove(min._x);
                }
            }
        }

        public bool TryApply(TDomain x, out TCodomain y)
        {
            var bst = Find(x);
            y = bst._y;
            return bst._used;
        }

        public int Count()
        {
            if (!_used)
                return 0;
            return 1 + (_left?.Count() ?? 0) + (_right?.Count() ?? 0);
        }

        BinarySearchTreePartialFunction<TDomain, TCodomain> Find(TDomain x)
        {
            if (!_used || x.Equals(_x))
                return this;

            if (x.CompareTo(_x) <= 0)
            {
                if (_left == null)
                    _left = new BinarySearchTreePartialFunction<TDomain, TCodomain>();

                return _left.Find(x);
            }
            else
            {
                if (_right == null)
                    _right = new BinarySearchTreePartialFunction<TDomain, TCodomain>();

                return _right.Find(x);
            }
        }

        BinarySearchTreePartialFunction<TDomain, TCodomain> FindMin(BinarySearchTreePartialFunction<TDomain, TCodomain> bst)
        {
            if (!IsEmpty(bst._left))
                return FindMin(bst._left);

            return bst;
        }

        bool IsEmpty(BinarySearchTreePartialFunction<TDomain, TCodomain> bst)
        {
            return bst == null || !bst._used;
        }
    }
}
