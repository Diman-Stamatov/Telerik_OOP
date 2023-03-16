using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private readonly List<Product> products;
        private readonly List<Category> categories;
        private readonly ShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<Product>();
            this.categories = new List<Category>();

            this.shoppingCart = new ShoppingCart();
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;

            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>(this.categories);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public Product FindProductByName(string productName)
        {
            
            var foundProduct = this.Products.Find(product => product.Name == productName);
            if (foundProduct == null)
            {
                throw new ArgumentException($"Product {productName} does not exist!");
            }
            return foundProduct;
        }

        public Category FindCategoryByName(string categoryName)
        {

            var foundCategory = this.Categories.Find(category => category.Name == categoryName);
            if (foundCategory == null)
            {
                throw new ArgumentException($"Category {categoryName} does not exist!");
            }
            return  foundCategory;
            
            
        }

        public void CreateCategory(string categoryName)
        {
            var newCategory = new Category(categoryName);
            this.categories.Add(newCategory);
            
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            
            var newProduct = new Product(name, brand, price, gender);
            this.products.Add(newProduct);
        }

        public bool CategoryExist(string categoryName)
        {
            
            bool categoryFound = this.Categories.Exists (category => category.Name == categoryName);
            return categoryFound;
            
        }

        public bool ProductExist(string productName)
        {
            
            bool productFound = this.Products.Exists(product => product.Name == productName);
            return productFound;
            
        }
    }
}
