
using Dealership.Models.Contracts;
using System.Collections.Generic;
using System.Data;

namespace Dealership.Models
{
    public class User: IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameError = "name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        public User(string username, string firstName, string lastName, string password, RoleType role)
        {

        }
        public string Username => throw new System.NotImplementedException();

        public string FirstName => throw new System.NotImplementedException();

        public string LastName => throw new System.NotImplementedException();

        public string Password => throw new System.NotImplementedException();

        public RoleType Role => throw new System.NotImplementedException();

        public IList<IVehicle> Vehicles => throw new System.NotImplementedException();

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            throw new System.NotImplementedException();
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
