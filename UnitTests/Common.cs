using SimpleInjector;
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
            Container.Register<IPartialFunction<string, int>, HashTableSeparateChainingPartialFunction<string, int>>();
        }
    }
}
