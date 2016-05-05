using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Mushrooms : Component
    {
        Pizza pizza;
        private double price = 20.0;

        public Mushrooms(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override double GetPrice()
        {
            return price + pizza.GetPrice();
        }
    }
}
