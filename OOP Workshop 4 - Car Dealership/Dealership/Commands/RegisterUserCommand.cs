﻿using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using System.Collections.Generic;
using static Dealership.Validator;
namespace Dealership.Commands
{
    public class RegisterUserCommand : BaseCommand
    {
        private const int ExpectedArgumentsCount = 4;
        public RegisterUserCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return false; }
        }

        protected override string ExecuteCommand()
        {
            ValidateArgumentsCount(this.CommandParameters, ExpectedArgumentsCount);

            string username = this.CommandParameters[0];
            string firstName = this.CommandParameters[1];
            string lastName = this.CommandParameters[2];
            string password = this.CommandParameters[3];

            RoleType role = RoleType.Normal;
            if (this.CommandParameters.Count == 5)
            {
                role = this.ParseRoleParameter(this.CommandParameters[4], "userRole");
            }

            return this.RegisterUser(username, firstName, lastName, password, role);
        }

        private string RegisterUser(string username, string firstName, string lastName, string password, RoleType role)
        {
            if (this.Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(BaseCommand.UserAlreadyLoggedIn, this.Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }

            if (this.Repository.UserExist(username))
            {
                string errorMessage = $"User {username} already exist. Choose a different username!";
                throw new AuthorizationException(errorMessage);
            }

            IUser user = this.Repository.CreateUser(username, firstName, lastName, password, role);
            this.Repository.AddUser(user);
            this.Repository.LogUser(user);

            return string.Format("User {0} registered successfully!", username);
        }
    }
}
