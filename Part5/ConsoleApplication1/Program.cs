using System;
using System.Collections.Generic;
using System.Linq;
using Task3;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Fibonacci fib = new Fibonacci();
            //List<decimal> fibList = fib.Fib(15);

            /* Task 4
            IEnumerable<double> count = fib.Task4(fibList);
            try
            {
                Console.Write(count.ElementAt(1));
            } catch(Exception)
            {
                Console.Write("!!!");
            }
            */

            //Task 5
            /*IEnumerable<decimal> count = fib.Task5(fibList);
            try
            {
                for (int i = 0; i < count.Count(); i++)
            {
                Console.Write(count.ElementAt(i) + " ");
            }
            }
            catch (Exception)
            {
                Console.Write("!!!");
            }*/

            //Task 7
            /*int max = fib.Task7(fibList);
            Console.Write(max);*/

            //Task 8
            /*double average = fib.Task8(fibList);
            Console.Write(average);*/

            //Task 6
            /*var list = fib.Task6(fibList);
            for (int i = 0; i < list.Count(); i++)
            {

                    Console.Write(list.ElementAt(i) + " ");

            }*/

            /*Customers c = new Customers();
            IDictionary<string, double> l = c.Linq_9();
            for (int i = 0; i < l.Count(); i++)
            {

                Console.Write(i + " " + l.ElementAt(i) + "\n");

            }*/

            Customers customer = new Customers();

            // 1.
            /*Customers customer = new Customers();
            List<string> customerList = customer.Linq0001(1000.0);
            string zero = customerList.ElementAt(0);

            foreach (var i in customerList)
            {
                string output = $"Customer {i}";
                Console.Write(output + "\n");
            }*/

            // 2.
            /*Customers customer = new Customers();
            IDictionary<string, List<string>> customerList = customer.Linq0002();
            List<string> germanyCustomers = customerList["Germany"];
            bool isTrue = germanyCustomers.Contains("ALFKI");

            foreach (var i in customerList)
            {
                string output = $"Customer {i}";
                Console.Write(output + "\n");
            }*/

            // 3.
            /*Customers customer = new Customers();
            List<string> customerList = customer.Linq0003(5000.0);

            foreach (var i in customerList)
            {
                string output = $"Customer {i}";
                Console.Write(output + "\n");
            }*/

            // 4.
            //var custList = customer.Linq0004();

            // 5.
            //var custList = customer.Linq0005();

            // 6.
            //var custList = customer.Linq0006();

            // 7.
            var custList = customer.Linq0008_3();


            Console.Read();
        }
    }
}
