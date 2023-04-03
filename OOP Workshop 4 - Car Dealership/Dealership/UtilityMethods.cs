using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Dealership.Commands.Enums;
using Dealership.Models;

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

    }
}
