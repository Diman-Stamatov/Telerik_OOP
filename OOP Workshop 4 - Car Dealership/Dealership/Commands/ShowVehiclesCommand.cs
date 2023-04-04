using static Dealership.Validator;
using Dealership.Core.Contracts;
using Dealership.Models.Contracts;
using System.Collections.Generic;

namespace Dealership.Commands
{
    public class ShowVehiclesCommand : BaseCommand
    {
        private const int ExpectedArgumentsCount = 1;
        public ShowVehiclesCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            ValidateArgumentsCount(this.CommandParameters, ExpectedArgumentsCount);

            string username = this.CommandParameters[0];

            return this.ShowUserVehicles(username);
        }

        private string ShowUserVehicles(string username)
        {
            IUser user = this.Repository.GetUser(username);

            return user.PrintVehicles();
        }
    }
}
