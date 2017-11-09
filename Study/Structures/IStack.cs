using System;

namespace Study.Structures
{
    public interface IStack<T>
    {
        void Push(T t);
        T Pop();
        T Top();
        bool IsEmpty();
        int Count();
    }
}
