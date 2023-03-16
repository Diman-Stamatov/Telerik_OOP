using System;
using System.Collections.Generic;
using static Cosmetics.Helpers.ValidationHelpers;
using static Cosmetics.Helpers.ParsingHelpers;

namespace Cosmetics.Models
{
    public class Product 
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;
        private double price;
        private string name;
        private string brand;
        private GenderType gender;

        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
            
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                throw new NotImplementedException("Not implemented yet.");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                string errorMessage = $"Please specify a product name that is " +
                    $"between {NameMinLength} and {NameMaxLength} characters!";
                ValidateStringLength(value, NameMinLength, NameMaxLength, errorMessage);
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
                string errorMessage = $"Please specify a brand name that is " +
                    $"between {BrandMinLength} and {BrandMaxLength} characters!";
                ValidateStringLength(value, BrandMinLength, BrandMaxLength, errorMessage);
                this.name = value;
            }
        }

        public GenderType Gender
        {
            set
            {
                string errorMessage = "Please input a valid product gender distinction!";
                this.gender = TryParseGender(value.ToString(), errorMessage);
            }
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {            
            return $"#[{this.Name}] [{this.Brand}]" +
                $"\n#Price: [{this.Price}]" +
                $"\n#Gender: [{this.Gender}]";
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
        public Product Clone()
        {
            var newProduct = new Product(this.name, this.brand, this.price, this.gender);
            return newProduct;
        }
        
    }
}