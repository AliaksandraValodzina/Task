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

            List<int> intMassive = new List<int>();
            List<double> doubleMassive = new List<double>();
            List<string> notNumbers = new List<string>();
            string inputValue = Console.ReadLine();

            while (!inputValue.Equals("QUIT", StringComparison.InvariantCultureIgnoreCase))
            {
                double value;
                if (Double.TryParse(inputValue, out value))
                {
                    if ((value % 1) == 0)
                    {
                        // Value is integer. Add it to array with integers.
                        intMassive.Add(Convert.ToInt32(value));
                    }
                    else
                    {
                        // Value is double. Add it to array with doubles.
                        doubleMassive.Add(value);
                    }
                }
                else
                {
                    // Value is not a number. Add it to array with strings.
                    notNumbers.Add(inputValue);
                }

                inputValue = Console.ReadLine();
            }

            // Write to console integers and average value.
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

            // Write to console doubles and average value.
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
            notNumbers.Sort();
            foreach (string element in notNumbers)
            {
                Console.CursorLeft = Console.BufferWidth - element.Length;
                Console.WriteLine(element);
            }
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}