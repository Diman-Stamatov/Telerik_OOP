namespace Agency.Models.Contracts
{
    public interface IAirplane :IVehicle, IHasId, ICopyable
    {
        bool IsLowCost { get; }
    }
}