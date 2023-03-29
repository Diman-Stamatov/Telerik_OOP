using System.Collections.Generic;
using System.Text;
using static CosmeticsShop.Helpers.ValidationHelpers;
using static CosmeticsShop.Helpers.UtilityMethods;
using System;
using System.Linq;

namespace CosmeticsShop.Models
{
    public class Category
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        
        private string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<Product>();
        }
        public Category(string name, List<Product> products)
        {
            this.Name = name;
            this.products = CloneProductsList(products);
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetThisMethodName();
                ValidateStringLength(MinNameLength, MaxNameLength, value, className , propertyName);
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                var clonedList = CloneProductsList(this.products);
                return clonedList;
            }
        }

        public void AddProduct(Product product)
        {
            if (this.products.Any(loggedProduct=>loggedProduct.Name == product.Name) == true)
            {
                throw new InvalidOperationException($"A product named {product.Name} has already been created!");
            }
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (this.products.Any(loggedProduct => loggedProduct.Name == product.Name) == false)
            {
                throw new InvalidOperationException($"A product named {product.Name} has already been created!");
            }
            
            this.products.RemoveAll(loggedProduct => loggedProduct.Name == product.Name);
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine($"#Category: {this.name}");

            if (this.products.Count == 0)
            {
                strBuilder.AppendLine(" #No products in this category");
                return strBuilder.ToString().Trim();
            }

            foreach (Product product in this.products)
            {
                strBuilder.AppendLine(product.Print());
                strBuilder.AppendLine(" ===");
            }

            return strBuilder.ToString().Trim();
        }
        public Category Clone()
        {
            string clonedName = this.Name;
            var clonedProducts = CloneProductsList(this.products);
            var clonedCategory = new Category(clonedName, clonedProducts);
            return clonedCategory;
        }
    }
}
