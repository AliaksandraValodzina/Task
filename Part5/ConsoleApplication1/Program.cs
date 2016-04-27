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
            List<decimal> fibList = fib.Fib(7);
            int count = fib.FibDevide(fibList);

            var simpleFibList = from f in fibList
                                let digits_sequence = f.ToString().Select(x => x - '0')
                                let sum = digits_sequence.Sum()
                                where (f % sum).Equals(0m)
                                select f;

            Console.Write(count);
            Console.Read();
        }
    }
}
