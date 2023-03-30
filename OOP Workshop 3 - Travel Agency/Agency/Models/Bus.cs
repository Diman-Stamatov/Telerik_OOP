using Agency.Models.Contracts;
using System;
using Agency.Exceptions;
using System.Text;


namespace Agency.Models
{
    public class Bus :Vehicle, IVehicle, IBus, IHasId
    {
        public new const int PassengerCapacityMinValue = 10;
        public new const int PassengerCapacityMaxValue = 50;

        private bool hasFreeTv;
        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
            :base(id, pricePerKilometer)
        {
            this.PassengerCapacity = passengerCapacity;
            this.HasFreeTv = hasFreeTv;
        }
        public new int PassengerCapacity
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
        public bool HasFreeTv
        {
            get
            {
                return this.hasFreeTv;
            }
            private set
            {
                this.hasFreeTv = value;
            }
        }

        public override IVehicle Copy()
        {
            Bus newBus = this;
            return newBus;
        }
        public override string ToString()
        {
            var vehicleInfo = new StringBuilder();
            vehicleInfo.Append(base.ToString());
            vehicleInfo.AppendLine($"Has free TV: {this.HasFreeTv}");
            return vehicleInfo.ToString().Trim();

        }

    }
}
