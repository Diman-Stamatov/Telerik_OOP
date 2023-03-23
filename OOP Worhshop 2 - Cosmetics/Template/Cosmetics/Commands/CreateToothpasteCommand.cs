using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string toothpasteName = this.CommandParameters[0];
            string toothpasteBrand = this.CommandParameters[1];
            decimal price = Decimal.Parse(this.CommandParameters[2]);
            GenderType genderType = (GenderType)Enum.Parse(typeof(GenderType), this.CommandParameters[3]);
            string ingredients = this.CommandParameters[4];

            return CreateToothpaste(toothpasteName, toothpasteBrand, price, genderType, ingredients);
        }

        private string CreateToothpaste(string toothpasteName, string toothpasteBrand, decimal price, GenderType genderType, string ingredients)
        {
            if (this.Repository.ProductExists(toothpasteName))
            {
                throw new ArgumentException(string.Format($"Product with name {toothpasteName} already exists!"));
            }

            this.Repository.CreateToothpaste(toothpasteName, toothpasteBrand, price, genderType, ingredients);

            return $"Product with name {toothpasteName} was created!";
        }

    }
}
