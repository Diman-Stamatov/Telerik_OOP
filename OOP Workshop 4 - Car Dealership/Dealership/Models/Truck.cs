
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Truck :Vehicle, ITruck
    {
        public const int TruckTires = 8;
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";

        public int WeightCapacity => throw new System.NotImplementedException();

        //ToDo
    }
}
