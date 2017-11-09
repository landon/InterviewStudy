using System;

namespace Study.Structures.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
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

        public T Dequeue()
        {
            return _data.RemoveFirst();
        }

        public void Enqueue(T t)
        {
            _data.Append(t);
        }

        public T Front()
        {
            return _data.GetHead();
        }
    }
}
