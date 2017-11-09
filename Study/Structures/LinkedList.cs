using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures
{
    public class LinkedList<T>
    {
        Item _head;
        Item _tail;

        public T GetHead()
        {
            if (IsEmpty())
                throw new Exception("empty list");
            return _head.T;
        }

        public bool IsEmpty()
        {
            return _head == null;
        }

        public void Prepend(T t)
        {
            _head = new Item(t, _head);
            if (_tail == null)
                _tail = _head;
        }

        public bool RemoveFirstWhere(Func<T, bool> condition)
        {
            if (IsEmpty()) return false;

            var i = _head;
            Item previous = null;
            while (i != null)
            {
                if (condition(i.T))
                {
                    if (previous == null)
                    {
                        _head = _head.Next;
                        if (_head == null)
                            _tail = null;
                    }
                    else
                    {
                        previous.Next = i.Next;
                        if (previous.Next == null)
                            _tail = previous;
                    }

                    return true;
                }

                previous = i;
                i = i.Next;
            }

            return false;
        }

        public bool TryFindWhere(Func<T, bool> condition, out T t)
        {
            t = default(T);
            if (IsEmpty()) return false;

            var i = _head;
            while (i != null)
            {
                if (condition(i.T))
                {
                    t = i.T;
                    return true;
                }

                i = i.Next;
            }

            return false;
        }

        public void Append(T t)
        {
            if (_tail == null)
            {
                Prepend(t);
            }
            else
            {
                var i = new Item(t, null);
                _tail.Next = i;
                _tail = i;
            }
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new Exception("empty list");

            var t = _head.T;
            _head = _head.Next;

            return t;
        }
        
        public int Count()
        {
            var count = 0;
            var i = _head;
            while (i != null)
            {
                i = _head.Next;
                count++;
            }

            return count;
        }

        class Item
        {
            public T T { get; private set; }
            public Item Next { get; set; }

            public Item(T t, Item next)
            {
                T = t;
                Next = next;
            }
        }
    }
}
