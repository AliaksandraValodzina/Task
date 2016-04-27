using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace Task2
{
    public class Fibonacci
    {
        // Create List with fibonacci numbers
        public List<decimal> Fib(int n)
        {
            List<decimal> fibonacciList = new List<decimal>();
            fibonacciList.Add(0);
            decimal[] f = new decimal[3];
            f[1] = 1;
            fibonacciList.Add(f[1]);
            fibonacciList.Add(f[1]);
            for (int i = 2; i <= n; i++)
            {
                f[i % 3] = f[(i + 1) % 3] + f[(i + 2) % 3];
                fibonacciList.Add(f[i % 3]);
            }
            return fibonacciList;
        }

        // A number is prime or not
        public bool IsPrime(decimal number)
        {
            if (number < 2m) return false;
            if (number == 2m) return true;
            if (number % 2 == 0m) return false;
            for (int i = 3; i * i <= number; i += 2)
                if (number % i == 0m) return false;
            return true;
        }

        // Prime numbers in fibbonacci List
        public IEnumerable<decimal> PrimeList(List<decimal> fib)
        {
            var simpleFibList = fib.Where(x => IsPrime(x));

            return simpleFibList;
        }

        // Sum numeral of numbers
        public int FibDevide(List<decimal> fib)
        {
            int sum = textBox1.Text.ToCharArray().Aggregate(1, (res, ch1) => res * (int)Char.GetNumericValue(ch1));

            var simpleFibList = from f in fib
                                let sum = f
                                where f % sum = 0
                                select f;

            return simpleFibList;
        }
    }

    [TestClass]
    public class FibonacciTest
    {
        [TestMethod]
        public void FibonacciListTest()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(100);
            decimal fib100 = fibList.ElementAt(101);
            Assert.AreEqual(fib100.Equals(354224848179261915075m), true);
        }

        [TestMethod]
        public void IsPrime()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(100);
            IEnumerable<decimal> primesList = fib.PrimeList(fibList);
            decimal fibPrime = primesList.ElementAt(5);
            Assert.IsTrue(fib.IsPrime(fibPrime));
        }
    }
}
