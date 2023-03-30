using Agency.Models.Contracts;
using System;
using Agency.Exceptions;
using System.Text;


namespace Agency.Models

{
    public class Train :Vehicle, IVehicle, ITrain, IHasId, ICopyable
    {
        public new const int PassengerCapacityMinValue = 30;
        public new const int PassengerCapacityMaxValue = 150;        
        public const int CartsMinValue = 1;
        public const int CartsMaxValue = 15;

        private int carts;
        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts)
            :base(id, pricePerKilometer)
        {
            this.PassengerCapacity = passengerCapacity;
            this.Carts = carts;
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
        public int Carts
        {
            get
            {
                return this.carts;
            }
            private set
            {
                ValidateCarts(value);
                this.carts = value;
            }
        }
        private void ValidateCarts(int carts)
        {
            if (carts < CartsMinValue || carts > CartsMaxValue)
            {
                string vehicleType = this.GetType().Name.ToLower();
                string errorMessage = "A {0} cannot have less than {1} cart or more than {2} carts.";
                throw new InvalidUserInputException(String.Format(errorMessage, 
                    vehicleType, CartsMinValue, CartsMaxValue));
            }
        }
        public override IVehicle Copy()
        {
            Train copiedTrain = this;
            return copiedTrain;
        }
        public override string ToString()
        {
            var vehicleInfo = new StringBuilder();
            vehicleInfo.Append(base.ToString());
            vehicleInfo.AppendLine($"Carts amount: {this.Carts}");
            return vehicleInfo.ToString().Trim();
        }

    }
}
