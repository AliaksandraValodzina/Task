using System;
using System.Linq;

namespace CommandPattern
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            Command command = null;

            Console.WriteLine(@"Enter a number\n");
            Console.WriteLine(@"1 - if you want to check prime number or not,\n");
            Console.WriteLine(@"2 - if you want to calculate a distance between two points,\n");
            Console.WriteLine(@"3 - if you want to calculate a sum of number.\n");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    Console.WriteLine("Enter a number\n");
                    var num = Console.ReadLine();
                    Number number = new Number(int.Parse(num));

                    command = new CheckPrime(number);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                case "2":
                    Console.WriteLine("Enter X and Y for first point\n");
                    var coordPoint1Str = Console.ReadLine();
                    double[] XYPoint1 = coordPoint1Str.Split(' ').Select(n => Convert.ToDouble(n)).ToArray();
                    Point point1 = new Point(XYPoint1[0], XYPoint1[1]);

                    Console.WriteLine("Enter X and Y for second point\n");
                    var coordPoint2Str = Console.ReadLine();
                    double[] XYPoint2 = coordPoint1Str.Split(' ').Select(n => Convert.ToDouble(n)).ToArray();
                    Point point2 = new Point(XYPoint2[0], XYPoint2[1]);

                    command = new DistanceCalculator(point1, point2);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                case "3":
                    Console.WriteLine("Enter a number\n");
                    var num2 = Console.ReadLine();
                    Number number2 = new Number(int.Parse(num2));

                    command = new NumeralCalculator(number2);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                default:
                    Console.WriteLine($"Not valid input - \"{consoleLine}\".\n");
                    break;
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}
        

        
