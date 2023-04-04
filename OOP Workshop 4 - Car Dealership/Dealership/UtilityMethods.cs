using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dealership.Commands.Enums;
using Dealership.Models;
using Dealership.Models.Contracts;

namespace Dealership
{
    internal class UtilityMethods
    {
        public static string GetMethodName([CallerMemberName] string memberName = null) 
        {
            return memberName.ToLower();
        }
        public static string GetCommandTypeNames()
        {            
            string commandNames = String.Join(", ", Enum.GetNames(typeof(CommandType))); 
            return commandNames;
        }
        public static string GetVehicleTypeNames()
        {
            string vehicleTypeNames = String.Join(", ", Enum.GetNames(typeof(VehicleType)));
            return vehicleTypeNames;
        }
        public static string GetRoleTypeNames()
        {
            string roleTypeNames = String.Join(", ", Enum.GetNames(typeof(RoleType)));
            return roleTypeNames;
        }
        public static IList<IComment> CloneCommentsList(IList<IComment> comments)
        {
            var clonedComments = new List<IComment>();
            foreach (var comment in comments)
            {
                clonedComments.Add(comment.Clone());
            }
            return clonedComments;
        }
        public static IList<IVehicle> CloneVehiclesList(IList<IVehicle> vehicles)
        {
            var clonedVehicles = new List<IVehicle>();
            foreach (var vehicle in vehicles)
            {
                clonedVehicles.Add(vehicle.Clone());
            }
            return clonedVehicles;
        }
        public static IList<IUser> CloneUsersList(IList<IUser> users)
        {
            var clonedUsers = new List<IUser>();
            foreach (var user in users)
            {
                clonedUsers.Add(user.Clone());
            }
            return clonedUsers;
        }

    }
}
