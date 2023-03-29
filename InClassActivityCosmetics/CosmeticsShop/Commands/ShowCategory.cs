using CosmeticsShop.Core;
using CosmeticsShop.Models;
using static CosmeticsShop.Helpers.ValidationHelpers;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class ShowCategory : ICommand
    {
        private const int ValidArgumentsCount = 1;

        private readonly CosmeticsRepository cosmeticsRepository;

        public ShowCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            string commandName = this.GetType().Name;
            ValidateArgumentsCount(ValidArgumentsCount, parameters, commandName);
            string categoryName = parameters[0];

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);

            return category.Print();
        }
    }
}
