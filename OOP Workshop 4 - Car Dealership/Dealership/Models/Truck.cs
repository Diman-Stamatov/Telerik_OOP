
using Dealership.Models.Contracts;
using static Dealership.UtilityMethods;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        public const int TruckWheels = 8;
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
            GenerateWheels(TruckWheels);
            GenerateType(TruckWheels);
        }
        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                string propertyName = GetMethodName();
                ValidateNumberPropertyValue(value, propertyName, MinCapacity, MaxCapacity);
                this.weightCapacity = value;
            }
        }
    }
}
