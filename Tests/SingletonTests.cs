using System;

using System.Threading;
using Singleton;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void NonThreadSafeSimpleSingletonTest()
        {
            for (var i = 0; i < 10; i++)
            {
                new Thread(() =>
                {
                    var instance = NonThreadSafeSimpleSingleton.Instance;
                }).Start();
            }

            Thread.Sleep(100);

            var counter = NonThreadSafeSimpleSingleton.InstanceCounter;
            Console.WriteLine("actual counter : " + counter.ToString());
            Assert.IsTrue(counter > 1);
        }

        [Test]
        public void ThreadSafeSimpleSingletonTest()
        {
            for (var i = 0; i < 10; i++)
            {
                new Thread(() =>
                {
                    var instance = ThreadSafeSimpleSingleton.Instance;
                }).Start();
            }
            Thread.Sleep(100);
            var counter = ThreadSafeSimpleSingleton.InstanceCounter;
            Console.WriteLine("actual counter : " + counter.ToString());
            Assert.IsTrue(counter == 1);
        }
    }
}
