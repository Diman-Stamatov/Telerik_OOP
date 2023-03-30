namespace Agency.Models.Contracts
{
    public interface IBus : IVehicle, IHasId, ICopyable
    {
        bool HasFreeTv { get; }
    }
}