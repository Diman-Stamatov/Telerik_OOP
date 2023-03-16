using System;
using System.Collections.Generic;
using static Cosmetics.Helpers.ProductManipulationHelpers;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            this.products = new List<Product>();
        }

        public List<Product> Products
        {
            get
            {
                
                var productsToReturn = DeepCopyProducts(this.products);
                return productsToReturn;
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
           int index = FindProductIndex(this.products, product);
            products.RemoveAt(index);
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
    }
}
