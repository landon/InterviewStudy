using System;

namespace Study.Structures
{
    public interface IPartialFunction<TDomain, TCodomain>
    {
        void Add(TDomain x, TCodomain y);
        void Remove(TDomain x);
        bool TryApply(TDomain x, out TCodomain y);
        int Count();
    }
}
