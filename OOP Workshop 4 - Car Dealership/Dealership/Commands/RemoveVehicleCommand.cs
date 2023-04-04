using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using static Dealership.Validator;
namespace Dealership.Commands
{
    public class RemoveVehicleCommand : BaseCommand
    {
        private const int ExpectedArgumentsCount = 1;
        public RemoveVehicleCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            ValidateArgumentsCount(this.CommandParameters, ExpectedArgumentsCount);
            int vehicleIndex = this.ParseIntParameter(this.CommandParameters[0], "vehicleIndex") - 1;
            return this.RemoveVehicle(vehicleIndex);
        }

        private string RemoveVehicle(int vehicleIndex)
        {
            ValidateIntRange(
                vehicleIndex,
                0,
                this.Repository.LoggedUser.Vehicles.Count,
                "Cannot remove this vehicle! The vehicle does not exist!");

            IVehicle vehicle = this.Repository.LoggedUser.Vehicles[vehicleIndex];
            this.Repository.LoggedUser.RemoveVehicle(vehicle);
            return $"{this.Repository.LoggedUser.Username} successfully removed a vehicle!";
        }
    }
}
