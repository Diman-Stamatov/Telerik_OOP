using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using static Cosmetics.Helpers.ValidationHelpers;
using static Cosmetics.Helpers.ClassManipulationHelpers;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;
        private string name;
        private List<Product> products;

        public Category(string name)
        {
            this.Name = name;
            Console.WriteLine($"Category with the name {this.Name} was created!");
        }
        public Category(string name, List<Product> products) : this (name)
        {
            this.products = CloneProductsList(products);
            Console.WriteLine($"Category with the name {this.Name} was created!");
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {                
                string errorMessage = $"Please specify a category name that is" +
                    $"between {NameMinLength} and {NameMaxLength}characters long!";
                ValidateStringLength(value, NameMinLength, NameMaxLength, errorMessage);
                this.name = value;
                products = new List<Product>();
            }
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
            Console.WriteLine($"Product {product.Name} was added to the category {this.Name}!");

        }

        public void RemoveProduct(Product product)
        {

            int productToRemoveIndex = FindProductIndex(this.products, product);
            products.RemoveAt(productToRemoveIndex);
            Console.WriteLine($"Product {product.Name} was removed from the category {this.Name}!");
        }

        public string Print()
        {

            var categoryOutput = new StringBuilder();
            categoryOutput.Append($"#Category: {this.Name}\n");
            for (int product = 0; product < products.Count; product++)
            {
                var currentProduct = products[product];
                categoryOutput.Append(currentProduct.Print() + 
                    "\n ===");                
            }
            if (products.Count == 0)
            {
                categoryOutput.Append($" #No products in this category");
            }
            return categoryOutput.ToString();
        }
        
        
    }
}

