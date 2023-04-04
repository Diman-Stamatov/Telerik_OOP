
using Dealership.Core.Contracts;
using static Dealership.Validator;
using static Dealership.PrintingHelpers;
using System.Collections.Generic;
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand :BaseCommand
    {
        
        public ShowUsersCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            var userStatus = this.Repository.LoggedUser.Role;
            ValidateAdminStatus(userStatus);
            return this.ShowRegisteredUsers();
        }

        private string ShowRegisteredUsers()
        {
            var userList = new StringBuilder();
            userList.AppendLine(ShowUsersPrintHeader);
            int userRow = 1;
            foreach (var user in this.Repository.Users)
            {
                userList.AppendLine($"{userRow}. {user.Print()}");
                userRow++;
            }
            return userList.ToString();
            
        }

    }
}
