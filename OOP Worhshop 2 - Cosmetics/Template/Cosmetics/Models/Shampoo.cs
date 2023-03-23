using Cosmetics.Models.Enums;
using System;
using Cosmetics.Models.Contracts;
using static Cosmetics.Helpers.ValidationHelper;
using System.Runtime.CompilerServices;

namespace Cosmetics.Models
{
    public class Shampoo :IProduct, IShampoo
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
        private int millilitres;
        private UsageType usage;

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
                ValidateStringLength(value, BrandMinLength, BrandMaxLength);
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
        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The mililiters cannot be negative!");
                }
                this.millilitres = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            set
            {
                this.usage = value;
            }
        }

        

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = Price;
            this.Gender = gender;
            this.Millilitres = millilitres;
            this.Usage = usage;
        }

        public string Print()
        {
            string message = $"{this.GetType().Name} with name {this.Name} was created!";
            return message;
        }
        public string GetCallerName([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}
