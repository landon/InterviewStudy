namespace FundamentCore.Numbers
{
    public class Prime : Generators.IterativeGenerator<int>
    {
        public Prime() : base(2, new PartialFunctions.Function<int, int>(Next)) { }

        static int Next(int n)
        {
            while (!IsPrime(++n)) ;
            return n;
        }

        static bool IsPrime(int n)
        {
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;

            return true;
        }
    }
}
