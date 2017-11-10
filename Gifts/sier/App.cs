using Bridge;
using Bridge.Html5;
using Newtonsoft.Json;
using System;

namespace sier
{
    public class App
    {
        public static void Main()
        {
            Func<int, int> w = t => (t + (t >> 31)) ^ (t >> 31);
            Func<int, int> r = t => -(-t >> 31);
            Func<bool> z = () =>
            {
                //System.Threading.Thread.Sleep(20);
                return true;
            };
            Func<string, bool> a = s =>
            {
                Console.Write(s);
                return true;
            };
            Func<int, int, bool> b = null;
            b = (n, k) => false;

            Func<int, bool> c = null;
            c = n => a("".PadLeft(40 - w(n) / 2, ' ')) &&
                     (b(w(n), 0) || true) && z() && a("\n") &&
                     (w(n) < 75 || n < 0) && c(n + 1);
            Func<bool> d = null;
            c(0);
            d = () => (c(-75) || true) && d();
            d();
        }
    }
}