namespace Dealership
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Dealership.Exceptions;

    public static class Validator
    {
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateDecimalRange(decimal value, decimal min, decimal max, string message)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException(message);
            }
        }

        public static void ValidateSymbols(string value, string pattern, string message)
        {
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (!regex.IsMatch(value))
            {
                throw new ArgumentException(message);
            }
        }
        public static void ValidateArgumentsCount(IEnumerable<String> arguments, int expectedArgumentsCount)
        {
            int actualArgumentsCount = arguments.Count();
            string errorMessage = $"Invalid number of arguments. Expected: {expectedArgumentsCount}, Received: {actualArgumentsCount}.";
            if (actualArgumentsCount != expectedArgumentsCount)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }
    }
}
