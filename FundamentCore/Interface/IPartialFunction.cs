namespace FundamentCore.Interface
{
    public interface IPartialFunction<in TDomain, out TCodomain>
    {
        bool IsDefined(TDomain x);
        TCodomain Apply(TDomain x);
        TCodomain TryApply(TDomain x, out bool wasDefined);
    }

    public interface IMutablePartialFunction<in TDomain, out TCodomain> : IPartialFunction<TDomain, TCodomain>
    {
        void Undefine(TDomain x);
        int DomainCount();
        IGenerate<TCodomain> GenerateCodomain();
    }

    public interface IFixedCodomainPartialFunction<in TDomain, TCodomain> : IMutablePartialFunction<TDomain, TCodomain>
    {
        void Add(TDomain x, TCodomain y);
        int FiberCount(TCodomain y);
    }

    public interface IFixedDomainAndCodomainPartialFunction<TDomain, TCodomain> : IFixedCodomainPartialFunction<TDomain, TCodomain>
    {
        IGenerate<TDomain> GenerateFiber(TCodomain y);
        IGenerate<TDomain> GenerateDomain();
    }
}
