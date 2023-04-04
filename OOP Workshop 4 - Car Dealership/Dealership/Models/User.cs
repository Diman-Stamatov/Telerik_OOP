using static Dealership.Validator;
using static Dealership.UtilityMethods;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dealership.Models
{
    public class User: IUser
    {
        private const int UsernameMinLength = 2;
        private const int UsernameMaxLength = 20;
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string NoSavedVehiclesMessage = "--NO VEHICLES--";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private RoleType role;
        private IList<IVehicle> vehicles;
        public User(string username, string firstName, string lastName, string password, RoleType role)
        {
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = role;
            this.vehicles = new List<IVehicle>();
        }
        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, UsernameMinLength, UsernameMaxLength);
                ValidateSymbols(value, UsernamePattern, InvalidUsernameFormatError);
                this.username = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, NameMinLength, NameMaxLength);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, NameMinLength, NameMaxLength);
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, PasswordMinLength, PasswordMaxLength);
                ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);      
                this.password = value;
            }
        }

        public RoleType Role
        {
            get
            {
                return this.role;
            }
            private set
            {
                this.role = value;
            }
        }

        public IList<IVehicle> Vehicles
        {
            get
            {
                return CloneVehiclesList(this.vehicles);
            }
            
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToCommentOn)
        {
            int vehicleIndex = this.vehicles.IndexOf(vehicleToCommentOn);
            this.vehicles[vehicleIndex].AddComment(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            ValidateAllowedVehiclesCount(this.vehicles, this.role);
            this.vehicles.Add(vehicle);
        }
        public string PrintVehicles()
        {
            if (this.vehicles.Count == 0)
            {
                return NoSavedVehiclesMessage;
            }
            var fulLVehiclesInfo = new StringBuilder();
            foreach (var vehicle in this.vehicles)
            {
                fulLVehiclesInfo.AppendLine(vehicle.Print());
                fulLVehiclesInfo.AppendLine(vehicle.PrintComments());
            }
            return fulLVehiclesInfo.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveCommentFrom)
        {
            string currentUser = this.Username;
            ValidateCommentAuthor(commentToRemove, currentUser);
            int vehicleIndex = this.vehicles.IndexOf(vehicleToRemoveCommentFrom);
            this.vehicles[vehicleIndex].RemoveComment(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }
        public IUser Clone()
        {
            var clonedUser = (User)this.MemberwiseClone();
            clonedUser.vehicles = CloneVehiclesList(this.vehicles);
            return clonedUser;
        }

        public string Print()
        {
            string userInfo = $"Username: {this.Username}, FullName: {this.FirstName} {this.LastName}, Role: {this.Role}";
            return userInfo;
        }
    }
}
