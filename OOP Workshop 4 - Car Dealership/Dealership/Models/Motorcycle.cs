
using Dealership.Models.Contracts;
using static Dealership.UtilityMethods;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {

        public const int MotorcycleWheels = 2;
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;

        private string category;
        public Motorcycle(string make, string model, decimal price, string category): base(make, model, price)
        {
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
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, propertyName, CategoryMinLength, CategoryMaxLength);
                this.category = value;
            }
        }

        
    }
}
