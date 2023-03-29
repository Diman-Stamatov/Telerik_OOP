using CosmeticsShop.Commands;
using CosmeticsShop.Enums;
using System;


namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            // TODO: Validate command format
            CosmeticsCommandType commandType = Enum.Parse<CosmeticsCommandType>(commandTypeValue, true);

            switch (commandType)
            {
                case CosmeticsCommandType.CreateCategory:
                    return new CreateCategory(productRepository);
                case CosmeticsCommandType.CreateProduct:
                    return new CreateProduct(productRepository);
                case CosmeticsCommandType.AddProductToCategory:
                    return new AddProductToCategory(productRepository);
                case CosmeticsCommandType.ShowCategory:
                    return new ShowCategory(productRepository);
                default:
                    // TODO: Can we improve this code?
                    return null;
            }
        }
    }
}
