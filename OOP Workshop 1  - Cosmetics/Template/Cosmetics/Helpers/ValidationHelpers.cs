using Cosmetics.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics.Helpers
{
    public class ValidationHelpers
    {
        public static void ValidateNumberRange(int minValue, int maxValue, int actualValue, string errorMessage)
        {
            if (actualValue < minValue || actualValue > maxValue)
            {
                throw new ArgumentException(errorMessage);
            }
        }
        public static void ValidateNumberRange(double minValue, double maxValue, double actualValue, string errorMessage)
        {
            if (actualValue < minValue || actualValue > maxValue)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void ValidateStringLength(string stringToValidate, int minLength, int maxLength, string errorMessage)
        {
            ValidateNumberRange(minLength, maxLength, stringToValidate.Length, errorMessage);
        }

        public static void ValidateArgumentsCount(IList<string> list, int expectedNumberOfParameters)
        {
            if (list.Count < expectedNumberOfParameters || list.Count > expectedNumberOfParameters)
            {
                throw new ArgumentException(string.Format($"Invalid number of arguments. Expected: {expectedNumberOfParameters}; received: {list.Count}."));
            }
        }
        
    }
}
