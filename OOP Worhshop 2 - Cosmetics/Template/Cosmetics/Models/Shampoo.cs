using Cosmetics.Models.Enums;
using System;
using Cosmetics.Models.Contracts;
using static Cosmetics.Helpers.ValidationHelper;
using System.Runtime.CompilerServices;

namespace Cosmetics.Models
{
    public class Shampoo :Product, IShampoo
    {
        

        private int millilitres;
        private UsageType usage;
        
        public int Millilitres
        {
            get
            {
                return this.millilitres;
            }
            set
            {
                string propertyName = GetPropertyName();
                ValidateNonNegative(value, propertyName);
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

        

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage): base(name, brand, price, gender)
        {
            
            this.Millilitres = millilitres;
            this.Usage = usage;
        }

        
        
    }
}
