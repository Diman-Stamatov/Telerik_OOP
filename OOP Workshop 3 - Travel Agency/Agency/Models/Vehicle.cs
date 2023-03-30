using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Exceptions;
using System.Runtime.ConstrainedExecution;
using ICopyable = Agency.Models.Contracts.ICopyable;
using static Agency.Models.Helpers.ValidationHelpers;

namespace Agency.Models
{
    public abstract class Vehicle : IVehicle, IHasId, ICopyable
    {
        public const int PassengerCapacityMinValue = 1;
        public const int PassengerCapacityMaxValue = 800;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        public const string InvalidPriceMessage = 
            "A {0} with a price per kilometer lower than ${1} or higher than ${2} cannot exist!";
        public const string InvalidPassengersCapacityMessage = "A {0} with less than {1} passengers" +
            " or more than {2} passengers cannot exist!";

        private protected int passengerCapacity;
        private protected double pricePerKilometers;
        private protected int id;

        protected Vehicle(int id, double pricePerKilometers)
        {
            this.Id = id;            
            this.PricePerKilometer = pricePerKilometers;

        }
        protected Vehicle(int id, int passengerCapacity, double pricePerKilometers) 
            :this(id, pricePerKilometers)
        {
            this.PassengerCapacity = passengerCapacity;
        }
        public int PassengerCapacity
        {
            get
            {
                return this.passengerCapacity;
            }
            private protected set
            {
                ValidatePassangerCapacity(value, PassengerCapacityMinValue, PassengerCapacityMaxValue);
                this.passengerCapacity = value;
            }
        }
        public double PricePerKilometer
        {
            get 
            { 
                return this.pricePerKilometers; 
            }
            private set 
            { 
                ValidatePricePerKilometers(value);
                this.pricePerKilometers = value; 
            }
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
        private protected void ValidatePassangerCapacity(int passengers, int  minPassengers, int maxPassengers)
        {
            if (passengers < minPassengers || passengers > maxPassengers)
            {
                string errorMessage = String.Format(InvalidPassengersCapacityMessage,
                    this.GetType().Name.ToLower(), minPassengers, maxPassengers);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        private protected void ValidatePricePerKilometers(double price)
        {
            if (price > PricePerKilometerMaxValue || price < PricePerKilometerMinValue)
            {
                string vehicleType = this.GetType().Name.ToLower();
                string errorMessage = String.Format(InvalidPriceMessage, 
                    vehicleType, PricePerKilometerMinValue, PricePerKilometerMaxValue);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public override string ToString()
        {
            var vehicleInfo = new StringBuilder();
            vehicleInfo.AppendLine($"{this.GetType().Name} ----");
            vehicleInfo.AppendLine($"Passenger capacity: {this.passengerCapacity}");
            vehicleInfo.AppendLine($"Price per kilometer: {this.pricePerKilometers}");
            return vehicleInfo.ToString();
        }
        public abstract IVehicle Copy();

    }
}
