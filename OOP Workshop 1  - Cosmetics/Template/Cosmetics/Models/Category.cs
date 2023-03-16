using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using static Cosmetics.Helpers.ValidationHelpers;

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
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
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
                var productsToReturn = DeepCopyProducts();               
                    
                return productsToReturn; 
            }
        }

        public void AddProduct(Product product)
        {
            
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {

            int productToRemoveIndex = FindProductIndex(this.products, product);
            products.RemoveAt(productToRemoveIndex);
        }

        public string Print()
        {

            var categoryOutput = new StringBuilder();
            categoryOutput.Append($"#Category: {this.Name}\n");
            for (int product = 0; product < products.Count; product++)
            {
                var currentProduct = products[product];
                categoryOutput.Append(currentProduct.Print() + 
                    "\n===");                
            }
            return categoryOutput.ToString();
        }
        private List<Product> DeepCopyProducts()
        {
            var clonedproductsList = new List<Product>();
            int numberOfProducts = this.products.Count;
            for (int index = 0; index < numberOfProducts; index++)
            {
                var clonedProduct = this.products[index].Clone();
                clonedproductsList.Add(clonedProduct);
            }
            return clonedproductsList;
        }
        private int FindProductIndex(List<Product> products, Product productToRemove)
        {
            int index = products.FindIndex(product => product.Name == productToRemove.Name
            && product.Brand == productToRemove.Brand
            && product.Gender == productToRemove.Gender);
            if (index < 0)
            {
                throw new ArgumentException("The specified product does not exist!");
            }
            return index;
        }
    }
}

