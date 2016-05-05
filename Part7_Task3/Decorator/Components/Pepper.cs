using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class Pepper : Component
    {
        Pizza pizza;
        private double price = 10.0;

        public Pepper(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override double GetPrice()
        {
            return price + pizza.GetPrice();
        }
    }
}
