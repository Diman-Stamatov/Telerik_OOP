using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateTicketCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateTicketCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        
        public override string Execute()
        {
            ValidateArgumentCount(this.CommandParameters, ExpectedNumberOfArguments);

            int journeyId = ParseIntParameter(this.CommandParameters[0], "journeyId");
            double administrativeCosts = ParseDoubleParameter(this.CommandParameters[1], "administrativeCosts");
            var journey = this.Repository.FindJourneyById(journeyId);
            var ticket = this.Repository.CreateTicket(journey, administrativeCosts);
            return $"A Ticket with the ID {ticket.Id} was created.";
            
        }
    }
}
