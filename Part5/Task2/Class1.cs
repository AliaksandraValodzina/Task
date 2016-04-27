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
            decimal[] f = new decimal[3];
            f[1] = 1;
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

        // 1. Prime numbers in fibbonacci List
        public IEnumerable<decimal> PrimeList(List<decimal> fib)
        {
            var simpleFibList = fib.Where(x => IsPrime(x));

            return simpleFibList;
        }

        // 2. How much numbers devide on sum numeral
        public int FibDevide(List<decimal> fib)
        {
            var simpleFibList = from f in fib
                                let digits_sequence = f.ToString().Select(x => x - '0')
                                let sum = digits_sequence.Sum()
                                where (f % sum).Equals(0m)
                                select f;

            return simpleFibList.Count();
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
            decimal fib100 = fibList.ElementAt(99);
            Assert.AreEqual(fib100.Equals(354224848179261915075m), true);
        }

        [TestMethod]
        public void Test1()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(100);
            IEnumerable<decimal> primesList = fib.PrimeList(fibList);
            decimal fibPrime = primesList.ElementAt(5);
            Assert.IsTrue(fib.IsPrime(fibPrime));
        }

        [TestMethod]
        public void Test2()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(7);
            int count = fib.FibDevide(fibList);
            Assert.AreEqual(count.Equals(6), true);
        }
    }
}
