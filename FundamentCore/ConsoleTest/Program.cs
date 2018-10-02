using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 100; i++)
            {
                var a = FloorOfSquareRoot3(i);
                var b = (int)Math.Sqrt(i);

                if (a != b)
                    Console.Write($"{i} :  {a} vs. {b}\t");
            }

            Console.ReadKey();
        }

        static int FloorOfSquareRoot3(int n)
        {
            return FindMyNumber(IsolateHighBit(n), x => x * x > n);
        }

        static int FloorOfSquareRoot2(int n)
        {
            return FindMyNumber(1 << FloorOfLog2(n), x => x * x > n);
        }

        static int FindMyNumber(int powerOfTwoUpperBound, Func<int, bool> isTooBig)
        {
            int result = 0;
            int bit = powerOfTwoUpperBound;

            while (bit >= 1)
            {
                result |= bit;
                if (isTooBig(result))
                    result ^= bit;
                bit >>= 1;
            }

            return result;
        }

        static int FindMyNumberByBits(int highestSetBitIndexUpperBound, Func<int, bool> isTooBig)
        {
            int result = 0;
            int bitIndex = highestSetBitIndexUpperBound;

            while (bitIndex >= 0)
            {
                int bit = 1 << bitIndex;
                result |= bit;
                if (isTooBig(result))
                    result ^= bit;
                bitIndex--;
            }

            return result;
        }

        static int FloorOfSquareRoot(int n)
        {
            return FindMyNumberByBits(FloorOfLog2(n), x => x * x > n);
        }

        static int FloorOfLog2(int n)
        {
            int result = 0;
            while (n >= 2)
            {
                result++;
                n >>= 1;
            }
            return result;
        }

        static int IsolateHighBit(int n)
        {
            while ((n & n-1) > 0)
                n &= n - 1;
            return n;
        }
    }
}
