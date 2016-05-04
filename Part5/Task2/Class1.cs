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
        public int Task1(List<decimal> fib)
        {
            var simpleFibList = fib.Where(x => IsPrime(x)).Count();

            return simpleFibList;
        }

        // 2. How much numbers devide on sum numeral
        public int Task2(List<decimal> fib)
        {
            var simpleFibList = from f in fib
                                let digitsSequence = f.ToString().Select(x => x - '0')
                                let sum = digitsSequence.Sum()
                                where (f % sum).Equals(0m)
                                select f;

            return simpleFibList.Count();
        }

        // 3.
        public string Task3(List<decimal> fib)
        {
            var resultList = from f in fib
                                where (f % 5).Equals(0m)
                                select f;

            return (resultList.Count() > 0) ? "List has number(s) divided by five" : "No number divided by five";
        }

        // 4.
        public IEnumerable<double> Task4(List<decimal> fib)
        {
            var resultList = from f in fib
                             where f.ToString().Contains('2')
                             select Math.Floor(Math.Sqrt(Decimal.ToInt32(f)));

            return resultList;
        }

        // 5.
        public IEnumerable<decimal> Task5(List<decimal> fib)
        {
            var resultList = fib
            .Where(f => f.ToString().Length > 1)
            .OrderByDescending(f => f.ToString().Take(2).Skip(1).ElementAt(0));

            return resultList;
        }

        // 6.
        public IEnumerable<decimal> Task6(List<decimal> fib)
        {
            var list = (from f in fib
                       let index = fib.IndexOf(f)
                       from p in (from k in fib
                                  let indexOne = index - 5
                                  let indexTwo = index + 5
                                  where fib.IndexOf(k) > indexOne && fib.IndexOf(k) < indexTwo
                                  select k)
                       let firstNum = f % 10
                       let secondNum = ((f - firstNum) % 100) / 10
                       where ((firstNum + secondNum) % 3).Equals(0m)
                       where p % 5 == 0
                       select f).Distinct();

            return list;
        }

        // 7.
        public int Task7(List<decimal> fib)
        {
            var resultList = from f in fib
                             let d = f.ToString().Select(x => x - '0')
                             let digitsSequence = d.Sum(x => x*x)
                             select digitsSequence;

            int max = resultList.Max();

            return max;
        }

        // 8.
        public double Task8(List<decimal> fib)
        {
            var list = from f in fib
                             select f.ToString().ToList();

            var chars = list.SelectMany(s => s);

            var zeroList = chars.Where(x => x.Equals('0'));

            double average = Math.Round(1.0 * zeroList.Count()/chars.Count(), 2);

            return average;
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
            List<decimal> fibList = fib.Fib(15);
            int fibPrime = fib.Task1(fibList);
            int count = 0;
            for (int i = 0; i < fibList.Count(); i++)
            {
                if (fib.IsPrime(fibList.ElementAt(i))) count++;
            }
            Assert.IsTrue(count.Equals(fibPrime));
        }

        [TestMethod]
        public void Test2()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(7);
            int count = fib.Task2(fibList);
            Assert.AreEqual(count.Equals(6), true);
        }

        [TestMethod]
        public void Test3()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(10);
            string returnedStr = fib.Task3(fibList);
            string result = "List has number(s) divided by five";
            Assert.AreEqual(returnedStr.Equals(result), true);
        }

        [TestMethod]
        public void Test4()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(10);
            var returnedList = fib.Task4(fibList);
            double root = returnedList.ElementAt(1);
            Assert.AreEqual(root.Equals(4), true);
        }

        [TestMethod]
        public void Test5()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(70);
            var returnedList = fib.Task5(fibList);
            decimal root = returnedList.ElementAt(0);
            Assert.AreEqual(root.Equals(55m), true);
        }

        [TestMethod]
        public void Test6()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(15);
            IEnumerable<decimal> result = fib.Task6(fibList);
            Assert.AreEqual(result.ElementAt(2).Equals(233), true);
        }

        [TestMethod]
        public void Test7()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(10);
            int max = fib.Task7(fibList);
            Assert.AreEqual(max.Equals(64), true);
        }

        [TestMethod]
        public void Test8()
        {
            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(15);
            double average = fib.Task8(fibList);
            Assert.AreEqual(average.Equals(0.04), true);
        }
    }
}
