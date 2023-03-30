using System;
using Agency.Models.Contracts;
using Agency.Exceptions;
using static Agency.Models.Helpers.ValidationHelpers;
using static Agency.Models.Helpers.UtilityMethods;
using System.Text;


namespace Agency.Models
{
    public class Journey :IJourney, IHasId, IDuplicateable
    {
        public const int StartLocationMinLength = 5;
        public const int StartLocationMaxLength = 25;
        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;
        public const int DistanceMinValue = 5;
        public const int DistanceMaxValue = 5000;

        private int id;
        private string startLocation;
        private string destination;
        private int distance;
        private IVehicle vehicle;

        public Journey(int id, string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.Id = id;
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
            
        }
        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            private set
            {
                string propertyName = GetThisMethodName();
                ValidateStringLength(value, StartLocationMinLength, StartLocationMaxLength, propertyName);
                this.startLocation = value;
            }
        }
        public string Destination
        {
            get
            {
                return this.destination;
            }
            private set
            {
                string propertyName = GetThisMethodName();
                ValidateStringLength(value, DestinationMinLength, DestinationMaxLength, propertyName);
                this.destination = value;
            }
        }
        public int Distance
        {
            get
            {
                return this.distance;
            }
            private set
            {
                ValidateDistance(value);
                this.distance = value;
            }
        }
        public IVehicle Vehicle
        {
            get
            {
                return this.vehicle.Clone();
            }
            private set
            {
                this.vehicle = value.Clone();
            }
        }
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                ValidateId(value);
                this.id = value;
            }
        }
        public double CalculatePrice()
        {
            double travelCosts = this.Distance * this.Vehicle.PricePerKilometer;
            return travelCosts;
        }
        private void ValidateDistance(int distance)
        {
            if (distance < DistanceMinValue || distance > DistanceMaxValue)
            {
                string errorMessage = $"The Distance cannot be less than {DistanceMinValue} " +
                    $"or more than {DistanceMaxValue} kilometers.";
                throw new InvalidUserInputException(errorMessage);
            }
        }
        
        public override string ToString()
        {
            var journeyLog = new StringBuilder();
            string className = this.GetType().Name;
            journeyLog.AppendLine($"{className} ----)");
            journeyLog.AppendLine($"Start location: {this.StartLocation}");
            journeyLog.AppendLine($"Destination: {this.Destination}");
            journeyLog.AppendLine($"Distance: {this.Distance}");
            journeyLog.AppendLine($"Travel costs: {this.CalculatePrice()}");
            return journeyLog.ToString().Trim();
        }

        public IJourney Duplicate()
        {
            throw new NotImplementedException();
        }
    }
}
