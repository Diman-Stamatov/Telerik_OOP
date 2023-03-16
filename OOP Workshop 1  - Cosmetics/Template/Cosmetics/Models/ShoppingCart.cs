using System;
using System.Collections.Generic;
using static Cosmetics.Helpers.ClassManipulationHelpers;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            this.products = new List<Product>();
        }
        public ShoppingCart(List<Product> products)
        {
            this.products = CloneProductsList(products);
        }

        public List<Product> Products
        {
            get
            {                
                var productsToReturn = CloneProductsList(this.products);
                return productsToReturn;
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
            Console.WriteLine($"Product {product.Name} was added to the shopping cart!");
        }

        public void RemoveProduct(Product product)
        {
           int index = FindProductIndex(this.products, product);
            products.RemoveAt(index);
            Console.WriteLine($"Product {product.Name} was removed from the shopping cart!");
        }

        public bool ContainsProduct(Product product)
        {
            bool productFound = ProductFound(this.products, product);
            return productFound;
        }

        public double TotalPrice()
        {
            double totalProductsPrice = (double)FindTotalProductPrice(this.products);
            return totalProductsPrice;
        }
        public  string PrintPrice(double price)
        {            
            if (price == 0)
            {
                return "No products in shopping cart!";
            }
            string priceMessage = $"The current shopping card products' total price is ${price}.";
            return priceMessage;
        }
    }
}
