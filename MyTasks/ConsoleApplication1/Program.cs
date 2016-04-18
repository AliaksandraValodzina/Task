using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            try
            {
                String readFrom = System.Configuration.ConfigurationManager.AppSettings["read"];
                if (readFrom.Equals("resource")){
                    String aStr = Resource1.num1;
                    a = Int32.Parse(aStr);

                    String bStr = Resource1.num2;
                    b = Int32.Parse(bStr);

                } else if (readFrom.Equals("console")) { 
                Console.WriteLine("Введите два числа в формате:");
                Console.WriteLine("[первое число] [пробел] [второе число]");
                Console.WriteLine("Пример: 12 32");
                //Read line, and split it by whitespace into an array of strings
                string[] tokens = Console.ReadLine().Split();

                //Parse element 0
                a = int.Parse(tokens[0]);

                //Parse element 1
                b = int.Parse(tokens[1]);
            }

                    String conf = System.Configuration.ConfigurationManager.AppSettings["choice"];

                    if (conf.Equals("library")) {
                        Class1 lib = new Class1();
                        int sum = lib.Sum(a, b);
                        Console.WriteLine("Сумма чисел {0} и {1} равна {2}", a, b, sum);

                        int sub = lib.Sub(a, b);
                        Console.WriteLine("Разность чисел {0} и {1} равна {2}", a, b, sub);

                        int mult = lib.Mult(a, b);
                        Console.WriteLine("произведение чисел {0} и {1} равно {2}", a, b, mult);

                        int dev = lib.Devide(a, b);
                        Console.WriteLine("Деление чисел {0} и {1} равно {2}", a, b, dev);
                        Console.ReadLine();

                } else if (conf.Equals("console")) {
                        Console.WriteLine("Сумма чисел {0} и {1} равна {2}", a, b, a + b);
                        Console.ReadLine();
                }

            } catch (Exception ex){
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
