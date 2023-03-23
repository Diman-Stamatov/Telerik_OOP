using Cosmetics.Models.Enums;
using System;
using Cosmetics.Models.Contracts;
using static Cosmetics.Helpers.ValidationHelper;
using System.Runtime.CompilerServices;

namespace Cosmetics.Models
{
    public class Shampoo :Product, IProduct, IShampoo
    {
        

        private int milliliters;
        private UsageType usage;
        
        public int Milliliters
        {
            get
            {
                return this.milliliters;
            }
            set
            {
                string propertyName = GetPropertyName();
                ValidateNonNegative(value, propertyName);
                this.milliliters = value;
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

        

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage): base(name, brand, price, gender)
        {
            
            this.Milliliters = millilitres;
            this.Usage = usage;
        }

        public override string Print()
        {
            return $"#{this.Name} {this.Brand}\n" +
                $" #Price: ${this.Price}\n" +
                $" #Gender: {this.Gender}\n" +
                $" #Millileters: {this.Milliliters}\n" +
                $" #Usage: {this.Usage}\n" +
                $" ===";
            
        }
    }
}
