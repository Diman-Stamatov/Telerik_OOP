using Cosmetics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Helpers
{
    public class ClassManipulationHelpers
    {
        public static Product CloneProduct(Product product)
        {
            var newProduct = new Product(product.Name, product.Brand, product.Price, product.Gender);
            return newProduct;
        }
        public static List<Product> CloneProductsList(List<Product> products)
        {
            var clonedproductsList = new List<Product>();
            int numberOfProducts = products.Count;
            for (int index = 0; index < numberOfProducts; index++)
            {
                var clonedProduct = CloneProduct(products[index]);
                clonedproductsList.Add(clonedProduct);
            }
            return clonedproductsList;
        }
        public static Category CloneCategory(Category category)
        {
            string clonedCategoryName = category.Name;
            var deepCopyProductList = CloneProductsList(category.Products);
            var clonedCategory = new Category(clonedCategoryName, deepCopyProductList);
            return clonedCategory; 
        }
        

        public static int FindProductIndex(List<Product> products, Product wantedProduct)
        {
            int index = products.FindIndex (product => product.Equals(wantedProduct));
            if (index < 0)
            {
                throw new ArgumentException("The specified product does not exist!");
            }
            return index;
        }

        public static bool ProductFound(List<Product> products, Product productToRemove)
        {
            bool productFound = products.Contains(productToRemove);
            return productFound;
        }
        public static double FindTotalProductPrice(List<Product> products)
        {
            int totalProducts = products.Count;
            double totalPrice = 0;
            for (int product = 0; product < totalProducts; product++)
            {
                totalPrice += products[product].Price;
            }
            return totalPrice;
        }
    }
}
