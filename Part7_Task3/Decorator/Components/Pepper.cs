using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    class Pepper : Component
    {
        Pizza pizza;
        private double price = 10.0;

        private Pepper(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override double GetPrice()
        {
            return price + pizza.GetPrice();
        }
    }
}
