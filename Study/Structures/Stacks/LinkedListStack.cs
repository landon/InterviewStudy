using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Structures.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        LinkedList<T> _data = new LinkedList<T>();

        public int Count()
        {
            return _data.Count();
        }

        public bool IsEmpty()
        {
            return _data.IsEmpty();
        }

        public T Pop()
        {
            return _data.RemoveFirst();
        }

        public void Push(T t)
        {
            _data.Prepend(t);
        }

        public T Top()
        {
            return _data.GetHead();
        }
    }
}
