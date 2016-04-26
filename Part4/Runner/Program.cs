using System;
using Task2;
using Task3;
using Task5;

namespace Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task2

            
            Fibonacci fibonacci = new Fibonacci();
            decimal numFibonacci = fibonacci.fib(100);
            Console.Write(numFibonacci);
            Console.Read();
            

            // Task3
            /*
            BasicClass classOne = new BasicClass();
            BasicClass classTwo = new BasicClass();
            Console.Write(BasicClass.count);
            Console.Read();
            */

            // Task5
            /*Rectangular rBig = new Rectangular();
            rBig.width = 10;
            rBig.heigth = 10;

            Rectangular rSmall = new Rectangular();
            rSmall.width = 3;
            rSmall.heigth = 1;

            RectangularWorker worker = new RectangularWorker();
            worker.RectInRect(rBig, rSmall);
            Console.Read();*/

        }
    }
}
