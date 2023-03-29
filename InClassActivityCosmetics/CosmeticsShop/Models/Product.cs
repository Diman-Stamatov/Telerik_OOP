using System;
using System.Text;
using CosmeticsShop.Enums;
using static CosmeticsShop.Helpers.ValidationHelpers;
using static CosmeticsShop.Helpers.UtilityMethods;

namespace CosmeticsShop.Models
{
    public class Product 
    {
        private const int MinNameLength = 3;
        private const int MaxNameLength = 10;
        private const int MinBrandLength = 2;
        private const int MaxBrandLength = 10;

        private string name;
        private string brand;
        private double price;
        private readonly GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetThisMethodName();
                ValidateStringLength(MinNameLength, MaxNameLength, value, className, propertyName);
                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetThisMethodName();
                ValidateStringLength(MinBrandLength, MaxBrandLength, value, className, propertyName);
                this.brand = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                string fieldName = GetThisMethodName(); 
                ValidatePositiveDouble(value, fieldName);
                this.price = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            var strBulder = new StringBuilder();
            strBulder.AppendLine($"#{this.name} {this.brand}");
            strBulder.AppendLine($" #Price: ${this.price}");
            strBulder.AppendLine($" #Gender: {this.gender}");

            return strBulder.ToString().Trim();
        }

        public Product Clone()
        {
            string clonedName = this.Name;
            string clonedBrand = this.Brand;
            double clonedPrice = this.Price;
            GenderType clonedGender = this.Gender;
            var clonedProduct = new Product(clonedName, clonedBrand, clonedPrice, clonedGender);
            return clonedProduct;
            
        }
    }
}
