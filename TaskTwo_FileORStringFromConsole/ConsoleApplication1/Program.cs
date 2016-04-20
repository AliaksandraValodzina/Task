using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Enter QUIT fot exit.";
            Console.WriteLine(message);

            var intMassive = new List<int>();
            var doubleMassive = new List<double>();
            var notNumbers = new List<String>();
            string inputValue = Console.ReadLine();

            while (!inputValue.Equals("QUIT", StringComparison.InvariantCultureIgnoreCase))
            {
                double value;
                if (Double.TryParse(inputValue, out value))
                {
                    if ((value % 1) == 0)
                    {
                        // Value is integer. Add it to massive with integers.
                        intMassive.Add(Convert.ToInt32(value));
                    }
                    else
                    {
                        // Value is double. Add it to massive with doubles.
                        doubleMassive.Add(value);
                    }
                }
                else
                {
                    // Value is not a number. Add it to massive with strings.
                    notNumbers.Add(inputValue);
                }

                inputValue = Console.ReadLine();
            }

            // Write to console integers and average of it.
            Console.WriteLine("");
            int iteratorInt = 0;
            int sumInt = 0;
            foreach (int element in intMassive)
            {
                string elementString = element.ToString();
                Console.CursorLeft = Console.BufferWidth - elementString.Length;
                Console.WriteLine(element);
                sumInt = sumInt + element;
                iteratorInt++;
            }
            int averageInt = (iteratorInt > 0) ? sumInt / iteratorInt : 0;
            string averageIntString = averageInt.ToString();
            Console.CursorLeft = Console.BufferWidth - averageIntString.Length;
            Console.WriteLine(averageInt);
            Console.WriteLine("");

            // Write to console doubles and average of it.
            int iteratorDouble = 0;
            double sumDouble = 0;
            foreach (double element in doubleMassive)
            {
                string elementString = element.ToString();
                Console.CursorLeft = Console.BufferWidth - elementString.Length;
                Console.WriteLine(element);
                sumDouble = sumDouble + element;
                iteratorDouble++;
            }
            double averageDouble = (iteratorDouble > 0) ? sumDouble / iteratorDouble : 0;
            string averageDoubleString = averageDouble.ToString();
            Console.CursorLeft = Console.BufferWidth - averageDoubleString.Length;
            Console.WriteLine(averageDouble);
            Console.WriteLine("");

            // Write to console not-a-numbers.
            foreach (string element in notNumbers)
            {
                Console.CursorLeft = Console.BufferWidth - element.Length;
                Console.WriteLine(element);
            }
            Console.WriteLine("");

            String str = "123";
            int code = (int)str[1];
            Console.WriteLine(code);

            Console.ReadLine();
        }
    }
}