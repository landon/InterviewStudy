using System;

namespace Study.Structures
{
    public interface ISet<T>
    {
        void Add(T t);
        void Remove(T t);
        bool Contains(T t);
    }
}
