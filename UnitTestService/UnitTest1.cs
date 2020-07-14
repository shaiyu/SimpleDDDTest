using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestService
{
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }


        [TestMethod]
        [DataRow(1, 2, 3)]
        public void TestMethod2(int a, int b, int sum)
        {
            Assert.IsTrue(a + b == sum);
        }

        [TestMethod]
        public void TestException()
        {
            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                var b = 0;
                //var a = 1 / b;
            });
        }
    }
}
