using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            //Choose a pizza
            Pizza pizza = null;
            startLoop:
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want a meat pizza,\n");
            Console.WriteLine($"2 - if you want a cheese pizza,\n");
            Console.WriteLine($"3 - if you want a vegitarian pizza,\n");

            var consoleLine = Console.ReadLine();
            
            switch (consoleLine)
            {
                case "1":
                    pizza = new MeatPizza();
                    break;
                case "2":
                    pizza = new CheesePizza();
                    break;
                case "3":
                    pizza = new PizzaVegitarian();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    goto startLoop;
            }

            //Choose a components
            Component component = null;
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want mushrooms,\n");
            Console.WriteLine($"2 - if you want a pepper,\n");
            Console.WriteLine($"3 - if you want a pepperoni,\n");

            consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    component = new Mushrooms();
                    break;
                case "2":
                    component = new Pepper();
                    break;
                case "3":
                    component = new Pepperoni();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    goto startLoop;
            }

        }
    }
}
