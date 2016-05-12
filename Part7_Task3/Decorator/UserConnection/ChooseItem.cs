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
            Console.WriteLine("Choose a pizza:");
            Console.WriteLine("Enter a number");
            Console.WriteLine("1 - if you want a meat pizza,");
            Console.WriteLine("2 - if you want a cheese pizza,");
            Console.WriteLine("3 - if you want a vegetarian pizza.");

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
                    Console.WriteLine("Invalid input. Try again choose a pizza.");
                    ChoosePizza();
                    break;
            }
        }

        //Choose a components
        public void ChooseComponent() 
        {
            Console.WriteLine("Choose a component:");
            Console.WriteLine("Enter a number");
            Console.WriteLine("1 - if you want more mushrooms,");
            Console.WriteLine("2 - if you want more pepper,");
            Console.WriteLine("3 - if you want more pepperoni.");
            Console.WriteLine("4 - nothing.");

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
                    Console.WriteLine("Invalid input. Try again add a component.");
                    ChooseComponent();
                    break;
            }
        }

        // One more components
        public void NextComponent()
        {
            Console.WriteLine("Do you want to choose one more component?");
            Console.WriteLine("Enter Y for yes, N for no.");

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
                    Console.WriteLine("Invalid input. Try again.");
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

            Console.WriteLine("Do you want to choose one more pizza?");
            Console.WriteLine("Enter Y for yes, N for no.");

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
