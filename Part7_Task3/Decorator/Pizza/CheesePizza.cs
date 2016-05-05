namespace Decorator.Components
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
