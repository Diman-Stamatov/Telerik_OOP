using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand :BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string creamName = this.CommandParameters[0];
            string creamBrand = this.CommandParameters[1];
            decimal price = ParseDecimalParameter(this.CommandParameters[2], "Price");
            ValidationHelper.ValidateNonNegative(price, "Price");
            GenderType genderType = ParseGenderType(this.CommandParameters[3]);
            ScentType scentType = ParseScentType(this.CommandParameters[4]);
            
            return CreateCream(creamName, creamBrand, price, genderType, scentType);
        }

        private string CreateCream(string creamName, string creamBrand, decimal price, GenderType gender, ScentType scent)
        {
            if (this.Repository.ProductExists(creamName))
            {
                throw new ArgumentException(string.Format($"Product with name {creamName} already exists!"));
            }

            this.Repository.CreateCream(creamName, creamBrand, price, gender, scent);

            return $"Product with name {creamName} was created!";
        }
    }
}
