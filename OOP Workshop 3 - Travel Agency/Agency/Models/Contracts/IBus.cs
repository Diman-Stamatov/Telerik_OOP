namespace Agency.Models.Contracts
{
    public interface IBus : IVehicle, IHasId
    {
        bool HasFreeTv { get; }
    }
}