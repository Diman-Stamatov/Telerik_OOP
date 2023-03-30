using System;

namespace Agency.Models.Contracts
{
    public interface IVehicle : IHasId, ICopyable
    {        
        int PassengerCapacity { get; }
        double PricePerKilometer { get; }
        abstract string ToString();
    }
}