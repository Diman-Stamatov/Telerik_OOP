using Dealership.Commands.Contracts;
using Dealership.Commands.Enums;
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using static Dealership.UtilityMethods;

namespace Dealership.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected const string UserAlreadyLoggedIn = "User {0} is already logged in! Please log out first!";
        private const string LoginRequiredError = "This command requires you to login first.";
        //ToDo w
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }

        public string Execute()
        {
            if (this.RequireLogin && this.Repository.LoggedUser == null)
            {
                throw new AuthorizationException(LoginRequiredError);
            }
            return this.ExecuteCommand();
        }

        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected abstract bool RequireLogin { get; }

        protected abstract string ExecuteCommand();

        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}. Please use an integer number.");
        }

        protected decimal ParseDecimalParameter(string value, string parameterName)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}. Please use a real number.");
        }

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid input for {parameterName}. Please use either true or false.");
        }
        
        protected RoleType ParseRoleParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out RoleType result))
            {
                return result;
            }
            string roleTypes = GetRoleTypeNames();
            throw new InvalidUserInputException($"Invalid input for {parameterName}. Please use one of the following: {roleTypes}.");
        }

        protected VehicleType ParseVehicleTypeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out VehicleType result))
            {
                return result;
            }
            string vehicleTypes = GetVehicleTypeNames();
            throw new InvalidUserInputException($"Invalid input for {parameterName}. Please use one of the following: {vehicleTypes}.");
        }
        
    }
}
