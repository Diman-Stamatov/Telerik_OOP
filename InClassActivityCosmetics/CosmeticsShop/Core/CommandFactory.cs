using CosmeticsShop.Commands;
using CosmeticsShop.Enums;
using System;
using static CosmeticsShop.Helpers.ValidationHelpers;


namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            ValidateCommandType(commandTypeValue);
            CosmeticsCommandType commandType = ParseCommandType(commandTypeValue);
            
            ICommand iCommand = null;
            switch (commandType)
            {
                case CosmeticsCommandType.CreateCategory:
                    iCommand = new CreateCategory(productRepository);
                    break;
                case CosmeticsCommandType.CreateProduct:
                    iCommand = new CreateProduct(productRepository);
                    break;
                case CosmeticsCommandType.AddProductToCategory:
                    iCommand = new AddProductToCategory(productRepository);
                    break;
                case CosmeticsCommandType.ShowCategory:
                    iCommand = new ShowCategory(productRepository);
                    break;
            }
            return iCommand;
        }
    }
}
