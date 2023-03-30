using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateAirplaneCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            ValidateArgumentCount(this.CommandParameters, ExpectedNumberOfArguments);
           
            int passengerCapacity = ParseIntParameter(this.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = ParseDoubleParameter(this.CommandParameters[1], "pricePerKilometer");
            bool isLowCost = ParseBoolParameter(this.CommandParameters[2], "isLowCost");

            var airplane = this.Repository.CreateAirplane(passengerCapacity, pricePerKilometer, isLowCost);
            return $"A Vehicle with the ID {airplane.Id} was created.";
            
        }
    }
}
