namespace Dealership
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Dealership.Exceptions;
    using Dealership.Models;
    using Dealership.Models.Contracts;
    using static Dealership.UtilityMethods;

    public static class Validator
    {
        private const string InvalidStringPropertyMessage = "The {0}'s {1} must be between {2} and {3} characters long!";
        private const string InvalidArgumentsCountMessage = "Invalid number of arguments. Expected: {0}, Received: {1}.";
        private const string InvalidRegisterArgumentsCountMessage = "Invalid number of arguments. Expected: {0} or {1}, Received: {2}.";
        private const int MaxAllowedVehiclesPerUser = 5;
        private const string NotAVipUserError = "You are not a VIP and cannot add more than {0} vehicles!";
        private const string AdminUserError = "You are an admin and therefore cannot add vehicles!";
        private const string NotTheAuthorError = "You are not the author of the comment you are trying to remove!";
        public const string InvalidAdminStatusError = "You are not an admin!";

        public static void ValidateIntRange(int value, int min, int max, string message)
        {
            if (value < min || value > max || min == max)
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
        public static void ValidateArgumentsCount(IEnumerable<String> arguments, int expectedArgumentsCountOne, int expectedArgumentsCountTwo)
        {
            int actualArgumentsCount = arguments.Count();
            string errorMessage = String.Format(InvalidRegisterArgumentsCountMessage, expectedArgumentsCountOne, expectedArgumentsCountTwo, actualArgumentsCount);
            if (actualArgumentsCount != expectedArgumentsCountOne && actualArgumentsCount != expectedArgumentsCountTwo)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateStringPropertyLength(string value, string className, string propertyName, int minLength, int maxLength)
        {
            string errorMessage = String.Format(InvalidStringPropertyMessage, className, propertyName, minLength, maxLength);
            ValidateStringNotNullOrEmpty(value, errorMessage);
            int valueLength = value.Length;
            if (valueLength < minLength || valueLength > maxLength)
            {   
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateStringNotNullOrEmpty(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value) == true)
            {
                throw new InvalidUserInputException(errorMessage);
            }
        }
        public static void ValidateAllowedVehiclesCount(IList<IVehicle> vehicles, RoleType role)
        {
            if (role == RoleType.Admin)
            {
                throw new AuthorizationException(AdminUserError);
            }
            int currentVehiclesCount = vehicles.Count;
            if (currentVehiclesCount == MaxAllowedVehiclesPerUser && role != RoleType.VIP)
            {
                string errorMessage = String.Format(NotAVipUserError, MaxAllowedVehiclesPerUser);
                throw new AuthorizationException(errorMessage);
            }
        }
        public static void ValidateCommentAuthor(IComment comment, string currentUser)
        {
            if (comment.Author != currentUser)
            {
                throw new AuthorizationException(NotTheAuthorError);
            }
        }
        public static void ValidateAdminStatus(RoleType role)
        {
            if (role != RoleType.Admin)
            {
                throw new AuthorizationException(InvalidAdminStatusError);
            }
        }
        
    }
}
