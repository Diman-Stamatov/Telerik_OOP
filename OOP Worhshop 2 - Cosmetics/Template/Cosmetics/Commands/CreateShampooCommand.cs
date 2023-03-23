using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string shampooName = this.CommandParameters[0];
            string shampooBrand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "Price");
            ValidationHelper.ValidateNonNegative(price, "Price");
            GenderType genderType = ParseGenderType(this.CommandParameters[3]);
            int milliliters = ParseIntParameter(this.CommandParameters[4], "Milliliters");
            UsageType usageType = (UsageType)Enum.Parse(typeof(UsageType), this.CommandParameters[5]);

            return CreateShampoo(shampooName, shampooBrand,  price,  genderType,  milliliters,  usageType);
        }

        private string CreateShampoo(string shampooName, string shampooBrand, decimal price, GenderType genderType, int milliliters, UsageType usageType)
        {
            if (this.Repository.ProductExists(shampooName))
            {
                throw new ArgumentException(string.Format($"Product with name {shampooName} already exists!"));
            }

            this.Repository.CreateShampoo(shampooName, shampooBrand, price, genderType, milliliters, usageType);

            return $"Product with name {shampooName} was created!";
        }


    }
}
