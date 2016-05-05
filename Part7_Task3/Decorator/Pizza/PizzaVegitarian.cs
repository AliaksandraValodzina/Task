using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    public class PizzaVegitarian : Pizza
    {
        private double price = 200.0;

        public override double GetPrice()
        {
            return price;
        }
    }
}
