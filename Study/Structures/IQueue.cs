using System;

namespace Study.Structures
{
    public interface IQueue<T>
    {
        void Enqueue(T t);
        T Front();
        T Dequeue();
        bool IsEmpty();
        int Count();
    }
}
