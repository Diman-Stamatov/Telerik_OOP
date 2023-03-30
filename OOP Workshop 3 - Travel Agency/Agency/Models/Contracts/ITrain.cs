namespace Agency.Models.Contracts
{
    public interface ITrain : IVehicle, IHasId, ICloneable
    {
        int Carts { get; }
    }
}