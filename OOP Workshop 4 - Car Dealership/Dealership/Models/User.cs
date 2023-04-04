using static Dealership.Validator;
using static Dealership.UtilityMethods;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Data;

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
        
        private const int MaxVehiclesToAdd = 5;
        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

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

        public void AddComment(IComment commentToAdd, IVehicle vehicleTocommentOn)
        {
            int vehicleIndex = this.vehicles.IndexOf(vehicleTocommentOn);
            this.vehicles[vehicleIndex].AddComment(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        public string PrintVehicles()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            throw new System.NotImplementedException();
        }

        
    }
}
