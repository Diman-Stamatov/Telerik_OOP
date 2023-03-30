namespace Agency.Models.Contracts
{
    public interface ITrain : IVehicle, IHasId
    {
        int Carts { get; }
    }
}