using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2
{
    public class Fibonacci
    {
        public decimal fib(int n)
        {
            decimal[] f = new decimal[3];
            f[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                f[i % 3] = f[(i + 1) % 3] + f[(i + 2) % 3];
            }
            return f[n % 3];
        }
    }

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Fibonacci f = new Fibonacci();
            decimal fib100 = f.fib(100);
            Assert.AreEqual(fib100.Equals(354224848179261915075m), true);
        }

    }
}
