namespace FundamentCore.Interface
{
    public enum SelfRanking
    {
        WorseThan = -1,
        SameAs = 0,
        BetterThan = 1
    }

    public interface IRankMyselfAgainstOthers<in T>
    {
        SelfRanking Rank(T other);
    }
}
