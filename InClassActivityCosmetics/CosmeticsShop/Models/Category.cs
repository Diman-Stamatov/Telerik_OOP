using System.Collections.Generic;
using System.Text;
using static CosmeticsShop.Helpers.ValidationHelpers;

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
                // return a copy
                return new List<Product>(this.products);
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            this.products.Remove(product);
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
        private List<Product> CloneProducts()
        {
            var clonedProducts = new List<Product>();
            int loggedProducts = this.products.Count;
            for (int product = 0; product < loggedProducts; product++)
            {
                clonedProducts.Add(products[0].Clone());
            }
            return clonedProducts;
        }
    }
}
