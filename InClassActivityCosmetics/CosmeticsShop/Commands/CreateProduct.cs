using CosmeticsShop.Core;
using CosmeticsShop.Models;
using CosmeticsShop.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using static CosmeticsShop.Helpers.ValidationHelpers;

namespace CosmeticsShop.Commands
{
    public class CreateProduct : ICommand
    {
        private const int ValidArgumentsCount = 4;

        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateProduct(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            string commandName = this.GetType().Name;
            ValidateArgumentsCount(ValidArgumentsCount, parameters, commandName);
            string name = parameters[0];
            string brand = parameters[1];

            double price = ParsePositiveDouble(parameters[2], "Price");

            GenderType gender = ParseGenderType(parameters[3]);
            
            this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"A product named {name} was created!";
        }
    }
}
