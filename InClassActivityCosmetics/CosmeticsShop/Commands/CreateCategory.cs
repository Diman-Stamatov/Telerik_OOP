using CosmeticsShop.Core;
using static CosmeticsShop.Helpers.ValidationHelpers;
using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : ICommand
    {
        private const int ValidArgumentsCount = 1;

        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            string commandName = this.GetType().Name;
            ValidateArgumentsCount(ValidArgumentsCount, parameters, commandName);
            string categoryName = parameters[0];

            this.cosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}
