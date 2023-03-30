using System;
using Agency.Models.Contracts;
using Agency.Exceptions;

namespace Agency.Models
{
    public class Ticket: ITicket, IHasId
    {
        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            throw new NotImplementedException();
        }

        public double AdministrativeCosts => throw new NotImplementedException();

        public IJourney Journey => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public double CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
