
using Dealership.Exceptions;
using Dealership.Models.Contracts;
using static Dealership.PrintingHelpers;
using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {

        public const int CarWheels = 4;
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const string InvalidSeatCountMessage = "The car's seats must be between {0} and {1}!";

        private int seats;
        
        public Car(string make, string model, decimal price, int seats) 
            : base(make, model, price)
        {
            this.type = VehicleType.Car;
            this.Seats = seats;
            GenerateWheels(CarWheels);
            GenerateType(CarWheels);
        }

        public int Seats
        {
            get 
            { 
                return this.seats; 
            }
            set 
            { 
                ValidateSeatsCount(value);
                this.seats = value; 
            }
        }
        private void ValidateSeatsCount(int value)
        {
            if (value < MinSeats || value > MaxSeats)
            {
                string errorMessage = string.Format(InvalidSeatCountMessage, MinSeats, MaxSeats);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public override string Print()
        {
            var carInfo = new StringBuilder();
            carInfo.Append(base.Print());
            string identation = CreateIndentation(VehicleIndentationLevel);
            carInfo.Append(identation + $"Seats: {this.Seats}");
            return carInfo.ToString();
        }
    }
}
