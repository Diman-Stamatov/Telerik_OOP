namespace Agency.Models.Contracts
{
    public interface IAirplane :IVehicle, IHasId, ICloneable
    {
        bool IsLowCost { get; }
    }
}