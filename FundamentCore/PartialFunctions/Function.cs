namespace FundamentCore.PartialFunctions
{
    public class Function<TDomain, TCodomain> : Interface.IPartialFunction<TDomain, TCodomain>
    {
        System.Func<TDomain, TCodomain> _apply;

        public Function(System.Func<TDomain, TCodomain> apply)
        {
            _apply = apply;
        }

        public TCodomain Apply(TDomain x)
        {
            return _apply(x);
        }

        public bool IsDefined(TDomain x)
        {
            return true;
        }

        public TCodomain TryApply(TDomain x, out bool wasDefined)
        {
            wasDefined = true;
            return Apply(x);
        }
    }
}
