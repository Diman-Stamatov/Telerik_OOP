using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Agency.Exceptions;

namespace Agency.Models.Helpers
{
    internal class ValidationHelpers
    {
        public static void ValidateStringLength(string inputString, int minlength, int maxLength, string methodName)
        {
            int actualLength = inputString.Length;
            if (actualLength < minlength || actualLength > maxLength)
            {
                string errorMessage = $"The {methodName}'s length cannot be " +
                    $"less than {minlength} or more than {maxLength} symbols long.";
                throw new InvalidUserInputException(errorMessage);
            }
        }
         
        public static void ValidateId(int id)
        {
            if (id < 0)
            {
                throw new InvalidUserInputException("The ID must be a positive number!");
            }
        }
       
    }
}
