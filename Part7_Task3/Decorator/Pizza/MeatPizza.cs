using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    public class MeatPizza : Pizza
    {
        private double price = 290.0;

        public override double GetPrice()
        {
            return price;
        }
    }
}
