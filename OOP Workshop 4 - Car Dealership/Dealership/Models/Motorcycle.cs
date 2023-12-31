﻿

using static Dealership.PrintingHelpers;
using static Dealership.UtilityMethods;
using static Dealership.Validator;
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {

        public const int MotorcycleWheels = 2;
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;

        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.type = VehicleType.Motorcycle;
            this.Category = category;
            GenerateWheels(MotorcycleWheels);
            GenerateType(MotorcycleWheels);
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, CategoryMinLength, CategoryMaxLength);
                this.category = value;
            }
        }

        public override string Print()
        {
            var bikeInfo = new StringBuilder();
            bikeInfo.Append(base.Print());
            string identation = CreateIndentation(VehicleIndentationLevel);
            bikeInfo.Append(identation + $"Category: {this.Category}");
            return bikeInfo.ToString();
        }

    }
}
