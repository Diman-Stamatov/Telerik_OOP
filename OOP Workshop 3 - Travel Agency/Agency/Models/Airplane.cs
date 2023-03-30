using Agency.Models.Contracts;
using System;
using Agency.Exceptions;
using System.Text;


namespace Agency.Models
{
    public class Airplane :Vehicle, IVehicle, IAirplane, IHasId
    {
        private bool isLowCost;
        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost) 
            :base(id, passengerCapacity, pricePerKilometer)
        {
            this.IsLowCost = isLowCost;
        }

        public bool IsLowCost
        {
            get 
            { 
                return isLowCost; 
            }
            private set
            {
                this.isLowCost = value;
            }
        }

        public override IVehicle Copy()
        {
            Airplane copiedAirplane = this;
            return copiedAirplane;
        }

        public override string ToString()
        {
            var vehicleInfo = new StringBuilder();
            vehicleInfo.Append(base.ToString());
            vehicleInfo.AppendLine($"Is low-cost: {this.IsLowCost}");
            return vehicleInfo.ToString().Trim();
        }
    }
}
