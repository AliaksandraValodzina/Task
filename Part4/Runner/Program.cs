using System;
using Task2;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            int numFibonacci = fibonacci.fib(7);
            Console.Write(numFibonacci);
            Console.Read();
        }
    }
}
