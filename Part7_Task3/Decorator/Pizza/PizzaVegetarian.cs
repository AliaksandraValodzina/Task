using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class PizzaVegetarian : Pizza
    {
        private double price = 200.0;

        public override double GetPrice()
        {
            return price;
        }
    }
}
