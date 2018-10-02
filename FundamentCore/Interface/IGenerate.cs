namespace FundamentCore.Interface
{
    public interface IGenerate<out T>
    {
        T Generate();
    }
}
