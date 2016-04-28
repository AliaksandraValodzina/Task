using System;
using System.Collections.Generic;
using Task2;
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Fibonacci fib = new Fibonacci();
            List<decimal> fibList = fib.Fib(10);
            IEnumerable<double> count = fib.Task4(fibList);
            try
            {
                Console.Write(count.ElementAt(1));
            } catch(Exception)
            {
                Console.Write("!!!");
            }
            Console.Read();
        }
    }
}
