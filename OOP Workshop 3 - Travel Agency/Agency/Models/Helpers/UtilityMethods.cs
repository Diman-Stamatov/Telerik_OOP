using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Helpers
{
    internal class UtilityMethods
    {
        public static string GetThisMethodName([CallerMemberName] string callerMemberName = null)
        {
            return callerMemberName;
        }
    }
}
