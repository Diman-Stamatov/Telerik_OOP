namespace Dealership
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Dealership.Exceptions;
    using static Dealership.UtilityMethods;

    public static class Validator
    {
        private const string InvalidStringPropertyMessage = "The {0}'s {1} must be between {2} and {3} characters long!";
        private const string InvalidArgumentsCountMessage = "Invalid number of arguments. Expected: {0}, Received: {1}.";
        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max)
            {
                throw new EntityNotFoundException(message);
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
                throw new InvalidUserInputException(message);
            }
        }
        public static void ValidateArgumentsCount(IEnumerable<String> arguments, int expectedArgumentsCount)
        {
            int actualArgumentsCount = arguments.Count();
            string errorMessage = String.Format(InvalidArgumentsCountMessage, expectedArgumentsCount, actualArgumentsCount);
            if (actualArgumentsCount != expectedArgumentsCount)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateStringPropertyLength(string value, string className, string propertyName, int minLength, int maxLength)
        {
            string errorMessage = String.Format(InvalidStringPropertyMessage, className, propertyName, minLength, maxLength);
            if (string.IsNullOrWhiteSpace(value) == true)
            {
                throw new InvalidUserInputException(errorMessage);
            }
            int valueLength = value.Length;
            if (valueLength < minLength || valueLength > maxLength)
            {   
                throw new InvalidUserInputException(errorMessage);
            }
        }
    }
}
