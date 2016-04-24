using System.Collections.Generic;

namespace Task4
{
    // Product interface
    public interface IProduct {
        int Id { get; set; }
        string Name { get; set; }
        string Category { get; set; }
        int Price { get; set; }
    }

    // Product class
    public class Product : IProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }
    }

    // Basket interface
    public interface IBasket
    {
        void AddToBasket(params Product[] products);

        void ClearBasket(params Product[] products);

        int SummaryCost();
    }

    // Basket class
    public class Basket : IBasket
    {
        public List<Product> productsInBasket { get; set; }

        public void AddToBasket(params Product[] products)
        {
            foreach (Product currentProduct in products) {
                productsInBasket.Add(currentProduct);
            }
        }

        public void ClearBasket(params Product[] products)
        {
            productsInBasket.Clear();
        }

        public int SummaryCost()
        {
            int summary = 0;

            foreach (Product currentProduct in productsInBasket)
            {
                summary += currentProduct.Price;
            }

            return summary;
        }
    }
}
