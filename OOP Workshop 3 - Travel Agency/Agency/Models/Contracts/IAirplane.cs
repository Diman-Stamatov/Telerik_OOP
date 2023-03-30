namespace Agency.Models.Contracts
{
    public interface IAirplane :IVehicle, IHasId
    {
        bool IsLowCost { get; }
    }
}