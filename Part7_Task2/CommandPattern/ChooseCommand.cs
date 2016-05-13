using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    class CommandController
    {
        Invoker invoker = new Invoker();
        Command command = null;

        public void Choose()
        {
            Console.WriteLine("Enter a number");
            Console.WriteLine("1 - if you want to check prime number or not,");
            Console.WriteLine("2 - if you want to calculate a distance between two points,");
            Console.WriteLine("3 - if you want to calculate a sum number's numerals.");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    Console.WriteLine("Enter a number");
                    var num = Console.ReadLine();
                    Number number = new Number(int.Parse(num));

                    command = new CheckPrime(number);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                case "2":
                    Console.WriteLine("Enter X and Y for first point");
                    double[] XYPoint1 = this.AddCoordinates();
                    Point point1 = new Point(XYPoint1[0], XYPoint1[1]);

                    Console.WriteLine("Enter X and Y for second point");
                    double[] XYPoint2 = this.AddCoordinates();
                    Point point2 = new Point(XYPoint2[0], XYPoint2[1]);

                    command = new DistanceCalculator(point1, point2);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                case "3":
                    Console.WriteLine("Enter a number");
                    var num2 = Console.ReadLine();
                    Number number2 = new Number(int.Parse(num2));

                    command = new NumeralCalculator(number2);

                    invoker.SetCommand(command);
                    invoker.Run();
                    break;
                default:
                    Console.WriteLine($"Not valid input - \"{consoleLine}\".\n");
                    Choose();
                    break;
            }

            Console.WriteLine("Enter a Y if you want to continue, N - if not.");
            consoleLine = Console.ReadLine();

            if (consoleLine == "Y")
            {
                Choose();
            }

            if (consoleLine == "N")
            {
                Console.WriteLine("Press any key to continue...");
            }
        }

        public double[] AddCoordinates()
        {
            double[] XYPoint = null;
            string coordPointStr  = null;
            try
            {
                coordPointStr = Console.ReadLine();
                XYPoint = coordPointStr.Split(' ').Select(n => Convert.ToDouble(n)).ToArray();
            } catch (Exception)
            {
                Console.WriteLine($"Invalid input - \"{coordPointStr}\". Try again.");
                coordPointStr = Console.ReadLine();
                XYPoint = coordPointStr.Split(' ').Select(n => Convert.ToDouble(n)).ToArray();
            }
            return XYPoint;
        }
    }
}
