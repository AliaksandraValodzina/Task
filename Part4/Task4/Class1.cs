using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    // Product interface
    public interface IProduct {
        int Id { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        string Price { get; set; }
    }

    // Product class
    public class Product : IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public string Price { get; set; }
    }

    // Basket interface
    public interface IBasket
    {
        void AddToBasket(params Product[] products);

        void ClearBasket(params Product[] products);

        void SummaryCost(params Product[] products);
    }

    // Basket class
    public class Basket : IBasket
    {
        public void AddToBasket(params Product[] products)
        {
            throw new NotImplementedException();
        }

        public void ClearBasket(params Product[] products)
        {
            throw new NotImplementedException();
        }

        public void SummaryCost(params Product[] products)
        {
            throw new NotImplementedException();
        }
    }
}
