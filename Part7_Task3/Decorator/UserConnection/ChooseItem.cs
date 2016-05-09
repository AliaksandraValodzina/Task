using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{ 
    public class ChooseItem
    {
        private Pizza pizza = null;
        private Component component = null;
        public int ComponentsCount { get; set; }
        public double Sum { get; set; }

        //Choose a pizza
        public void ChoosePizza()
        {
            Console.WriteLine($"Choose a pizza:\n");
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want a meat pizza,\n");
            Console.WriteLine($"2 - if you want a cheese pizza,\n");
            Console.WriteLine($"3 - if you want a vegetarian pizza.\n");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    pizza = new MeatPizza();
                    ChooseComponent();
                    break;
                case "2":
                    pizza = new CheesePizza();
                    ChooseComponent();
                    break;
                case "3":
                    pizza = new PizzaVegetarian();
                    ChooseComponent();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again choose a pizza.\n");
                    ChoosePizza();
                    break;
            }
        }

        //Choose a components
        public void ChooseComponent() 
        {
            Console.WriteLine($"Choose a component:\n");
            Console.WriteLine($"Enter a number\n");
            Console.WriteLine($"1 - if you want more mushrooms,\n");
            Console.WriteLine($"2 - if you want more pepper,\n");
            Console.WriteLine($"3 - if you want more pepperoni.\n");
            Console.WriteLine($"4 - nothing.\n");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "1":
                    component = new Mushrooms(pizza);
                    ComponentsCount++;
                    NextComponent();
                    break;
                case "2":
                    component = new Pepper(pizza);
                    ComponentsCount++;
                    NextComponent();
                    break;
                case "3":
                    component = new Pepperoni(pizza);
                    ComponentsCount++;
                    NextComponent();
                    break;
                case "4":
                    NextPizza();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again add a component.\n");
                    ChooseComponent();
                    break;
            }
        }

        // One more components
        public void NextComponent()
        {
            Console.WriteLine($"Do you want to choose one more component?\n");
            Console.WriteLine($"Enter Y for yes, N for no.\n");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "Y":
                    pizza = component;
                    ChooseComponent();
                    break;
                case "N":
                    NextPizza();
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.\n");
                    NextComponent();
                    break;
            }
        }

        // One more pizza
        public void NextPizza() 
        {
            AddToPrice();
            pizza = null;
            component = null;

            Console.WriteLine($"Do you want to choose one more pizza?\n");
            Console.WriteLine($"Enter Y for yes, N for no.\n");

            var consoleLine = Console.ReadLine();

            switch (consoleLine)
            {
                case "Y":
                    ChoosePizza();
                    break;
                case "N":
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again");
                    NextPizza();
                    break;
            }
        }

        // Add to sum
        public void AddToPrice()
        {
            if (!(component == null)) Sum += component.GetPrice();
            if ((component == null)) Sum += pizza.GetPrice();
        }

        // Check a sale
        public void CheckPrise()
        {
            if (ComponentsCount > 1) Sum = Sum * 0.95;
        }

    }
}
