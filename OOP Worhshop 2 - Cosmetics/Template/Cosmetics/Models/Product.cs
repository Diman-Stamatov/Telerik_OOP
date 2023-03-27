using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using static Cosmetics.Helpers.ValidationHelper;

namespace Cosmetics.Models
{
    public abstract class Product:IProduct 
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;
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
                string propertyName = GetPropertyName();
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

        private protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }
        public abstract string Print();       
        public static string GetPropertyName([CallerMemberName] string methodName = null)
        {
            return methodName;
        }
    }

}
