﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Study.Structures;
using Study.Structures.Stacks;
using System.Linq;
using Study.Algorithms;

namespace UnitTests
{
    [TestClass]
    public class TestDataStructures
    {
        static Random RNG = new Random(101);
        [TestMethod]
        public void Sorter_Test()
        {
            var sorter = Common.Container.GetInstance<ISorter<int>>();

            var items = new int[100000];
            for (int i = 0; i < items.Length; i++)
                items[i] = RNG.Next(100000);

            var reference = string.Join(",", items.OrderBy(x => x));

            sorter.Sort(items);
            var ours = string.Join(",", items);

            Assert.AreEqual(reference, ours);
        }

        [TestMethod]
        public void ISortedPartialFunction_Test()
        {
            var reference = new System.Collections.Generic.SortedDictionary<string, int>();
            var f = Common.Container.GetInstance<ISortedPartialFunction<string, int>>();

            var sentence = @"A man a plan a canal panama. That is a palindrome.  Blah, donkey's are fun like myopic squid. blah what
carl mike time john, 845 the apricot is not an orange, it is an orange not it is the other indeed";
            var words = sentence.Split(' ');
            foreach (var w in words)
            {
                f.Add(w, w.Length);
                reference[w] = w.Length;
            }

            Assert.AreEqual(f.Count(), reference.Count);

            f.Remove("palindrome.");
            reference.Remove("palindrome.");

            Assert.AreEqual(f.Count(), reference.Count);

            int xc;
            Assert.IsFalse(f.TryApply("palindrome.", out xc));

            foreach (var w in words)
            {
                int c;
                var found = f.TryApply(w, out c);
                Assert.IsTrue(w == "palindrome." || found);
                if (w != "palindrome.")
                    Assert.AreEqual(c, w.Length);
            }

            Assert.AreEqual(f.Count(), reference.Count);

            var rr = string.Join(";", reference.Select(kvp => kvp.Key));
            var uu = string.Join(";", f.EnumerateSorted().Select(kvp => kvp.Item1));

            Assert.AreEqual(rr, uu);
        }

        [TestMethod]
        public void IPartialFunction_Test()
        {
            var f = Common.Container.GetInstance<IPartialFunction<string, int>>();

            var sentence = "A man a plan a canal panama. That is a palindrome.  Blah, donkey's are fun like myopic squid.";
            var words = sentence.Split(' ');
            foreach (var w in words)
                f.Add(w, w.Length);

            f.Remove("palindrome.");
            int xc;
            Assert.IsFalse(f.TryApply("palindrome.", out xc));

            foreach (var w in words)
            {
                int c;
                var found = f.TryApply(w, out c);
                Assert.IsTrue(w == "palindrome." || found);
                if (w != "palindrome.")
                    Assert.AreEqual(c, w.Length);
            }
        }

        [TestMethod]
        public void IQueue_Test()
        {
            var queue = Common.Container.GetInstance<IQueue<int>>();

            for (int x = 1; x <= 100; x++)
                queue.Enqueue(x);

            for (int x = 1; x <= 100; x++)
                Assert.AreEqual(x, queue.Dequeue());
        }

        [TestMethod]
        public void IStack_ToBinaryTest()
        {
            for (int x = 1; x <= 100; x++)
                Assert.AreEqual(ToBinary(x), Convert.ToString(x, 2));
        }

        string ToBinary(int x)
        {
            var stack = Common.Container.GetInstance<IStack<int>>();
            while (x > 0)
            {
                stack.Push(x % 2);
                x /= 2;
            }

            var binary = "";
            while(!stack.IsEmpty())
                binary += stack.Pop();

            return binary;
        }
    }
}
