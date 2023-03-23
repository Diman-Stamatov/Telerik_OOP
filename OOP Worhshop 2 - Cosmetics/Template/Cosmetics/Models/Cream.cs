using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models
{
    internal class Cream: Product, IProduct, ICream
    {
        public new const int NameMinLength = 3;
        public new const int NameMaxLength = 15;
        public new const int BrandMinLength = 3;
        public new const int BrandMaxLength = 15;

        private ScentType scent;

        public ScentType Scent
        {
            get
            {
                return this.scent;
            }
            set
            {                
                
                this.scent = value;
            }
        }

        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) : base(name, brand, price, gender)
        {
            this.Scent = scent;
        }
        public override string Print()
        {
            return $"#{this.Name} {this.Brand}\n" +
                $" #Price: ${this.Price}\n" +
                $" #Gender: {this.Gender}\n" +
                $" #Scent: {this.Scent}\n" +
                $" ===";

        }
    }
}
