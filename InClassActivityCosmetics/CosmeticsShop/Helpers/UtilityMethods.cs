using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Helpers
{
    internal class UtilityMethods
    {
        public static List<Product> CloneProductsList(List<Product> products)
        {
            var clonedProducts = new List<Product>();
            int loggedProducts = products.Count;
            for (int product = 0; product < loggedProducts; product++)
            {
                clonedProducts.Add(products[product].Clone());
            }
            return clonedProducts;
        }
        public static List<Category> CloneCategoriesList(List<Category> categories)
        {
            var clonedCategories = new List<Category>();
            int loggedCategories = categories.Count;
            for (int category = 0; category < loggedCategories; category++)
            {
                clonedCategories.Add(categories[category].Clone());
            }
            return clonedCategories;
        }
        public static string GetThisMethodName([CallerMemberName] string callerMemberName = null)
        {
            return callerMemberName;
        }
    }
}
