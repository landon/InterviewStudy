using SimpleInjector;
using Study.Algorithms;
using Study.Algorithms.Sorters;
using Study.Structures;
using Study.Structures.PartialFunctions;
using Study.Structures.Queues;
using Study.Structures.Stacks;
using System;

namespace UnitTests
{
    static class Common
    {
        public static Container Container;

        static Common()
        {
            Container = new Container();
            Container.Register<IStack<int>, LinkedListStack<int>>();
            Container.Register<IQueue<int>, LinkedListQueue<int>>();
            Container.Register<IPartialFunction<string, int>, HashtablePartialFunction<string, int>>();
            Container.Register<ISortedPartialFunction<string, int>, SkipListPartialFunction<string, int>>();

            Container.Register<ISorter<int>, MergeSorter<int>>();
        }
    }
}
