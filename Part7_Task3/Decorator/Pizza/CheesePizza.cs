using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class CheesePizza : Pizza
    {
        private double price = 250.0;

        public override double GetPrice()
        {
            return price;
        }
    }
}
