using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dealership
{
    internal class UtilityMethods
    {
        public static string GetMethodName([CallerMemberName] string memberName = null) 
        {
            return memberName.ToLower();
        }
    }
}
