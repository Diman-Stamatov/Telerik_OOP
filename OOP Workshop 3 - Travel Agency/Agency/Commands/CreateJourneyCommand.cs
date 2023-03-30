using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models.Contracts;

using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateJourneyCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 4;

        public CreateJourneyCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentCount(this.CommandParameters, ExpectedNumberOfArguments);

            string startLocation = this.CommandParameters[0];
            string destination = this.CommandParameters[1];
            int distance = ParseIntParameter(base.CommandParameters[2], "distance");
            int vehicleId = ParseIntParameter(base.CommandParameters[3], "vehicleId");
            IVehicle vehicle = this.Repository.FindVehicleById(vehicleId);

            var journey = this.Repository.CreateJourney(startLocation, destination, distance, vehicle);
            return $"A Journey with the ID {journey.Id} was created.";
        }
    }
}
