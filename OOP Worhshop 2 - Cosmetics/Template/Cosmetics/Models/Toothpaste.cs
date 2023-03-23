using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using static Cosmetics.Helpers.ValidationHelper;

namespace Cosmetics.Models
{
    public class Toothpaste :IProduct, IToothpaste
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int brandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
        private string ingredients;
        public string Name
        { 
            get
            {
                return this.name;

            }
            set
            {
                ValidateStringLength(value, NameMinLength, NameMaxLength);
                this.name = value;
            }
        }
        public string Brand
        {
            get
            {
                return this.brand;

            }
            set
            {
                ValidateStringLength(value, BrandMinLength, brandMaxLength);
                this.brand = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                string propertyName = "Price";
                ValidateNonNegative(value, propertyName);
                this.price = value;
            }
        }
        public GenderType Gender
        {
            get 
            { 
                return this.gender; 
            }
            set
            {
                this.gender = value;
            }
        }
        public string Ingredients
        {
            get { return this.ingredients; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Please specify the toothpaste ingredients!");
                }
                this.ingredients = value;
            }
        }        

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
            this.Ingredients = ingredients;
        }

        

        public string Print()
        {
            string message = $"{this.GetType().Name} with name {this.Name} was created!";
            return message;
        }
    }
}
