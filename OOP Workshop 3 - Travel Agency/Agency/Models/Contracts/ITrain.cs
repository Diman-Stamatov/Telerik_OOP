namespace Agency.Models.Contracts
{
    public interface ITrain : IVehicle, IHasId, ICopyable
    {
        int Carts { get; }
    }
}