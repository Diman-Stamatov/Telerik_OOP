namespace Agency.Models.Contracts
{
    public interface IBus : IVehicle, IHasId, ICloneable
    {
        bool HasFreeTv { get; }
    }
}