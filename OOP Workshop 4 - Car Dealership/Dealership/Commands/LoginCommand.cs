using Dealership.Core.Contracts;
using Dealership.Exceptions;
using static Dealership.Validator;
using System.Collections.Generic;

namespace Dealership.Commands
{
    public class LoginCommand : BaseCommand
    {
        private const int ExpectedArgumentsCount = 2;
        public LoginCommand(List<string> parameters, IRepository repository)
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
            string password = this.CommandParameters[1];

            return this.Login(username, password);
        }

        private string Login(string username, string password)
        {
            if (this.Repository.LoggedUser != null)
            {
                string errorMessage = string.Format(BaseCommand.UserAlreadyLoggedIn, this.Repository.LoggedUser.Username);

                throw new AuthorizationException(errorMessage);
            }

            var user = this.Repository.GetUser(username);
            if (user.Password != password)
            {
                throw new AuthorizationException("Wrong username or password!");
            }

            this.Repository.LogUser(user);

            return $"User {username} successfully logged in!";
        }
    }
}
