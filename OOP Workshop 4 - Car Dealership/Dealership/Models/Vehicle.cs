using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dealership.UtilityMethods;
using Dealership.Exceptions;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;        
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const string InvalidStringPropertyMessage = "The {0}'s {1} must be between {2} and {3} characters long!";
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidPriceMessage = "The {0}'s price must be between {1} and {2}!";

        private string make;
        private string model;
        private VehicleType type;
        private int wheels;
        private decimal price;
        
        protected Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, propertyName, MakeMinLength, MakeMaxLength);
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, propertyName, ModelMinLength, ModelMaxLength);
                this.model = value;
            }
        }
        public VehicleType Type
        {
            get
            {
                return this.type;
            }
        }
        public int Wheels
        {
            get
            {
                return this.wheels;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                ValidatePrice(value);
                this.price = value;
            }
        }

        protected void ValidateStringPropertyLength(string value, string propertyName, int minLength, int maxLength)
        {
            int valueLength = value.Length;
            if (valueLength < minLength || valueLength > maxLength)
            {
                string vehicleName = this.GetType().Name;
                string errorMessage = String.Format(InvalidStringPropertyMessage, vehicleName, propertyName, minLength, maxLength);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        private void ValidatePrice(decimal price)
        {
            if (price < MinPrice || price> MaxPrice)
            {
                string vehicleName = this.GetType().Name;
                string errorMessage = String.Format(InvalidPriceMessage, vehicleName, MinPrice, MaxPrice);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        protected void GenerateType(int wheels)
        {
            this.type = (VehicleType)wheels;
        }
        protected void GenerateWheels(int wheels)
        {
            this.wheels = wheels;
        }
        
    }
}
