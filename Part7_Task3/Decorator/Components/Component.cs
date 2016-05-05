using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Components
{
    public abstract class Component : Pizza
    {
        Pizza pizza;
        private double price;
    }
}
