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
            double sum = 0;

            //Choose a pizza
            Pizza pizza = null;
            startAddPizza:
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want a meat pizza,\n");
            Console.WriteLine($"2 - if you want a cheese pizza,\n");
            Console.WriteLine($"3 - if you want a vegitarian pizza.\n");

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
                    goto startAddPizza;
            }

            //Choose a components
            startAddComponents:
            Component component = null;
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want more mushrooms,\n");
            Console.WriteLine($"2 - if you want more pepper,\n");
            Console.WriteLine($"3 - if you want more pepperoni.\n");
            Console.WriteLine($"4 - nothing.\n");

            consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    component = new Mushrooms(pizza);
                    break;
                case "2":
                    component = new Pepper(pizza);
                    break;
                case "3":
                    component = new Pepperoni(pizza);
                    break;
                case "4":
                    goto nextPizza;
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    goto startAddComponents;
            }

            startMoreComponents:
            // One more components
            Console.WriteLine($"Do you want to choose one more component?\n");
            Console.WriteLine($"Enter Y for yes, N for no.\n");

            consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "Y":
                    pizza = component;
                    goto startAddComponents;
                case "N":
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    goto startMoreComponents;
            }

            nextPizza:
            sum += component.GetPrice();

            // One more pizza
            Console.WriteLine($"Do you want to choose one more pizza?\n");
            Console.WriteLine($"Enter Y for yes, N for no.\n");

            consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "Y":
                    goto startAddComponents;
                case "N":
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    goto startAddPizza;
            }

            // Print and wait for user
            Console.WriteLine($"Sum = {sum}");
            Console.ReadKey();
        }
    }
}
