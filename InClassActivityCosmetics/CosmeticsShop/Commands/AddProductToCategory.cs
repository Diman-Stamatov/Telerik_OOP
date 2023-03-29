using CosmeticsShop.Core;
using CosmeticsShop.Models;
using static CosmeticsShop.Helpers.ValidationHelpers;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class AddProductToCategory : ICommand
    {
        private const int ValidArgumentsCount = 2;

        private readonly CosmeticsRepository cosmeticsRepository;

        public AddProductToCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            string commandName = this.GetType().Name;
            ValidateArgumentsCount(ValidArgumentsCount, parameters, commandName);

            string categoryName = parameters[0];
            string productName = parameters[1];
            
            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);
            Product product = this.cosmeticsRepository.FindProductByName(productName);

            category.AddProduct(product);

            return $"The product {productName} was added to the category {categoryName}!";
        }
    }
}
