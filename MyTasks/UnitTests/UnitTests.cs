using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SumTest()
        {
            int a = 10;
            int b = 15;
            Class1 calc = new Class1();
            int sum = calc.Sum(a, b);
            Assert.AreEqual(25, sum, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void SubTest()
        {
            int a = 29;
            int b = 15;
            Class1 calc = new Class1();
            int sub = calc.Sub(a, b);
            Assert.AreEqual(14, sub, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void MultTest()
        {
            int a = 2;
            int b = 15;
            Class1 calc = new Class1();
            int mult = calc.Mult(a, b);
            Assert.AreEqual(30, mult, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void DevTest()
        {
            int a = 10;
            int b = 5;
            Class1 calc = new Class1();
            int dev = calc.Devide(a, b);
            Assert.AreEqual(2, dev, 0.001, "Account not debited correctly");
        }
    }
}
