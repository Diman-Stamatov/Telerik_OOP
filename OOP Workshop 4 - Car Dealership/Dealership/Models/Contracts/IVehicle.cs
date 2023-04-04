namespace Dealership.Models.Contracts
{
    public interface IVehicle :IPriceable, ICommentable, IPrintable
    {
        string Make { get; }

        string Model { get; }

        VehicleType Type { get; }

        int Wheels { get; }

        IVehicle Clone(); 

        bool Equals(object vehicle);

        string PrintComments();
        

    }
}
