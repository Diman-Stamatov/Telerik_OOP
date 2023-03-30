using System;
using Agency.Models.Contracts;
using Agency.Exceptions;

namespace Agency.Models
{
    public class Journey :IJourney, IHasId
    {
        public const int StartLocationMinLength = 5;
        public const int StartLocationMaxLength = 25;
        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;
        public const int DistanceMinValue = 5;
        public const int DistanceMaxValue = 5000;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public string StartLocation => throw new NotImplementedException();

        public string Destination => throw new NotImplementedException();

        public int Distance => throw new NotImplementedException();

        public IVehicle Vehicle => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();

        public double CalculatePrice()
        {
            throw new NotImplementedException();
        }
    }
}
