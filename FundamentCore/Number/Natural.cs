namespace FundamentCore.Numbers
{
    public class Natural : Generators.IterativeGenerator<int>
    {
        public Natural() : base(0, new PartialFunctions.Function<int, int>(n => n + 1)) { }
    }
}
