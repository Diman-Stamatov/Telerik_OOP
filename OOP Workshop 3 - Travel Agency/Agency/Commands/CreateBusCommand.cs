using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;

using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateBusCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateBusCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentCount(this.CommandParameters, ExpectedNumberOfArguments);

            int passengerCapacity = ParseIntParameter(this.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = ParseDoubleParameter(this.CommandParameters[1], "pricePerKilometer");
            bool hasFreeTv = ParseBoolParameter(this.CommandParameters[2], "hasFreeTv");

            var bus = this.Repository.CreateBus(passengerCapacity, pricePerKilometer, hasFreeTv);
            return $"A Vehicle with the ID {bus.Id} was created.";
        }
    }
}
