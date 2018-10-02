namespace FundamentCore.Interface
{
    public interface ISortedPartialFunction<TDomain, TCodomain> : IPartialFunction<TDomain, TCodomain>
        where TDomain : IRankMyselfAgainstOthers<TDomain>
    {
        IGenerate<System.Tuple<TDomain, TCodomain>> GenerateSorted();
    }
}