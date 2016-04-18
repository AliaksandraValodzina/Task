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
            try
            {
                do
                {
                    Console.WriteLine("Введите два числа в формате:" );
                    Console.WriteLine("[первое число] [пробел] [второе число]");
                    Console.WriteLine("Пример: 12 32");
                    //Read line, and split it by whitespace into an array of strings
                    string[] tokens = Console.ReadLine().Split();

                    //Parse element 0
                    int a = int.Parse(tokens[0]);

                    //Parse element 1
                    int b = int.Parse(tokens[1]);


                    Console.WriteLine("Сумма чисел {0} и {1} равна {2}", a, b, a + b);

                    Console.WriteLine("Для выхода нажмите Escape; для продолжения - любую другую клавишу");
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
