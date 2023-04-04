using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dealership.UtilityMethods;
using Dealership.Exceptions;
using static Dealership.Validator;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;        
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidNumberPropertyMessage = "The {0}'s {1} must be between {2} and {3}!";

        private string make;
        private string model;
        protected VehicleType type;
        private int wheels;
        private decimal price;
        private IList<IComment> comments;

        protected Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                string className = this.GetType().Name;               
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, MakeMinLength, MakeMaxLength);
                this.make = value;
            }
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, ModelMinLength, ModelMaxLength);
                this.model = value;
            }
        }
        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            
        }
        public int Wheels
        {
            get
            {
                return this.wheels;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                string propertyName = GetMethodName();
                ValidateNumberPropertyValue(value, propertyName, MinPrice, MaxPrice);
                this.price = value;
            }
        }
        public IList<IComment> Comments
        {
            get
            {
                return CloneCommentsList(this.comments);
            }
            private set
            {
                this.comments = CloneCommentsList(value);
            }
            
        }
        protected void ValidateNumberPropertyValue(decimal value, string propertyName, decimal minValue, decimal maxValue)
        {
            if (value < minValue || value > maxValue)
            {
                string vehicleName = this.GetType().Name;
                string errorMessage = String.Format(InvalidNumberPropertyMessage, vehicleName, propertyName, minValue, maxValue);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        protected void ValidateNumberPropertyValue(int value, string propertyName, int minValue, int maxValue)
        {
            if (value < minValue || value > maxValue)
            {
                string vehicleName = this.GetType().Name;
                string errorMessage = String.Format(InvalidNumberPropertyMessage, vehicleName, propertyName, minValue, maxValue);
                throw new InvalidUserInputException(errorMessage);
            }
        }
        protected void GenerateType(int wheels)
        {
            this.type = (VehicleType)wheels;
        }
        protected void GenerateWheels(int wheels)
        {
            this.wheels = wheels;
        }
        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }
        public void RemoveComment(IComment comment)
        {
            this.comments.Remove(comment);
        }        
        public IVehicle Clone()
        {
            Vehicle clonedVehicle = (Vehicle)this.MemberwiseClone();
            clonedVehicle.Comments = this.Comments;            
            return clonedVehicle;
        }
        public override bool Equals(object vehicle)
        {
            bool areEqual = false;
            var comparedVehicle = vehicle as IVehicle;
            if (comparedVehicle == null)
            {
                return areEqual;
            }
            if (comparedVehicle.Make == this.Make
                && comparedVehicle.Model == this.Model
                && comparedVehicle.Type == this.Type
                && comparedVehicle.Price == this.Price)
            {
                areEqual = true;
            }
            return areEqual;
        }

        public virtual string Print()
        {
            var vehicleInfo = new StringBuilder();

        }

        public string PrintComments()
        {
            throw new NotImplementedException();
        }
    }
}
