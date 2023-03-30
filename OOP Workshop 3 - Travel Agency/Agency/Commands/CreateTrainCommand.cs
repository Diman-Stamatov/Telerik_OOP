using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;

using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateTrainCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateTrainCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentCount(this.CommandParameters, ExpectedNumberOfArguments);
            int passengerCapacity = ParseIntParameter(base.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = ParseDoubleParameter(base.CommandParameters[1], "pricePerKilometer");
            int cartsCount = ParseIntParameter(base.CommandParameters[2], "cartsCount");

            var train = this.Repository.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            return $"A Vehicle with the ID {train.Id} was created.";
        }
    }
}
