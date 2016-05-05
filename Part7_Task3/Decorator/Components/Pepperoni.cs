using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Pepperoni : Component
    {
        Pizza pizza;
        private double price = 30.0;

        private Pepperoni(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override double GetPrice()
        {
            return price + pizza.GetPrice();
        }
    }
}
