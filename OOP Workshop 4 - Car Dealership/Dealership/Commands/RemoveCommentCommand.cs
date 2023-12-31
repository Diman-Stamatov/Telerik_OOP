﻿using static Dealership.Validator;
using Dealership.Core.Contracts;
using Dealership.Models.Contracts;
using System.Collections.Generic;

namespace Dealership.Commands
{
    public class RemoveCommentCommand : BaseCommand
    {
        private const int ExpectedArgumentsCount = 3;

        public RemoveCommentCommand(List<string> parameters, IRepository repository)
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

            int vehicleIndex = this.ParseIntParameter(this.CommandParameters[0], "vehicleIndex") - 1;
            int commentIndex = this.ParseIntParameter(this.CommandParameters[1], "vehicleIndex") - 1;
            string username = this.CommandParameters[2];

            return this.RemoveComment(vehicleIndex, commentIndex, username);
        }

        private string RemoveComment(int vehicleIndex, int commentIndex, string username)
        {
            IUser user = this.Repository.GetUser(username);

            ValidateIntRange(
                vehicleIndex,
                0,
                user.Vehicles.Count,
                "This vehicle does not exist!");

            IVehicle vehicle = user.Vehicles[vehicleIndex];

            ValidateIntRange(
                commentIndex,
                0,
                user.Vehicles[vehicleIndex].Comments.Count,
                "Cannot remove this comment! The comment does not exist!");

            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            this.Repository.LoggedUser.RemoveComment(comment, vehicle);

            return $"{this.Repository.LoggedUser.Username} successfully removed a comment!";
        }
    }
}
