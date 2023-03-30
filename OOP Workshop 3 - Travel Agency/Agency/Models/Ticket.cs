using System;
using Agency.Models.Contracts;
using Agency.Exceptions;
using static Agency.Models.Helpers.ValidationHelpers;
using System.Text;

namespace Agency.Models
{
    public class Ticket: ITicket, IHasId
    {
        private int id;
        private IJourney journey;
        private double administrativeCosts;
        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            this.Id = id;
            this.Journey = journey;
            this.AdministrativeCosts = administrativeCosts;
        }
        public int Id
        {
            get 
            { 
                return this.id; 
            }
            private set
            {
                ValidateId(value);
                this.id = value;
            }
        }
        public IJourney Journey
        {
            get
            {
                return this.journey.Clone();
            }
            private set
            { 
                this.journey = value.Clone(); 
            }
        }
        public double AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            private set
            {
                ValidateAdministraticeCosts(value);
                this.administrativeCosts = value;
            }
        }

        public double CalculatePrice()
        {
            double travelCosts = this.journey.CalculatePrice();
            double totalPrice = travelCosts * this.administrativeCosts;
            return totalPrice;
        }
        public override string ToString()
        {
            var ticketInfo = new StringBuilder();
            string className = this.GetType().Name;
            ticketInfo.AppendLine($"{className} ----)");
            ticketInfo.AppendLine($"Destination: {this.journey.Destination}");
            ticketInfo.AppendLine($"Prices: {this.CalculatePrice()}");
            return ticketInfo.ToString().Trim();
        }
        private void ValidateAdministraticeCosts(double costs)
        {
            if (costs < 0)
            {
                string errorMessage = "The Administrative costs must be a positive number!";
                throw new InvalidUserInputException(errorMessage);
            }
        }
    }
}
