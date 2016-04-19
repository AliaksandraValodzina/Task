using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Для выхода из программы введите STOP.";
            Console.WriteLine(message);

            string text = string.Empty;
            char[] arr;
            var intMassive = new List<char>();
            var doubleMassive = new List<char>();

            do {
                text = Console.ReadLine();
                arr = text.ToCharArray();

                foreach (char element in arr) {
                if (char.IsDigit(element)) {
                
                    if ((element % 1) == 0) {
                            // Char is integer
                            intMassive.Add(element);
                    }else {
                            // Char is double
                            doubleMassive.Add(element);
                    }
                }

                }

            } while (!text.Equals("quit", StringComparison.InvariantCultureIgnoreCase));

            foreach (char element in intMassive) {
                //Console.CursorLeft = Console.BufferWidth;
                Console.WriteLine(element);
            }

            Console.ReadLine();
        }
    }
}
