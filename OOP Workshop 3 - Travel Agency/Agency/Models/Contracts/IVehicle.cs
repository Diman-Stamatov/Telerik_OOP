using System;

namespace Agency.Models.Contracts
{
    public interface IVehicle : IHasId, ICloneable
    {        
        int PassengerCapacity { get; }
        double PricePerKilometer { get; }
        abstract string ToString();
    }
}