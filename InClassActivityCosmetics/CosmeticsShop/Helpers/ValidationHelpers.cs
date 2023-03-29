using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CosmeticsShop.ApplicationErrors;
using CosmeticsShop.Enums;

namespace CosmeticsShop.Helpers
{
    internal class ValidationHelpers
    {
        public static void ValidateStringLength(int minLength, int maxLength, string inputString, 
            string currentClass, string fieldBeingValidated )
        {
            int realLength = inputString.Length;
            if (inputString == null ||realLength < minLength || realLength > maxLength)
            {
                throw new ParameterLengthException($"The {currentClass} {fieldBeingValidated} must be " +
                    $"between {minLength} and {maxLength} characters long!");
            }
        }
        public static void ValidateDoubleFromString(string possibleDouble, string fieldBeingValidated)
        {
            
            if (double.TryParse(possibleDouble, out double stringAsDouble) == false)
            {
                throw new NumberValueException($"The {fieldBeingValidated} must be a number!");
            }
             
        }
        public static void ValidatePositiveDouble(double number, string fieldBeingValidated) 
        {
            if (number < 0)
            {
                throw new NumberValueException($"The {fieldBeingValidated} must be a positive number!");
            }
        }
        public static double ParseDouble(string possibleDouble, string fieldBeingValidated)
        {
            ValidateDoubleFromString(possibleDouble, fieldBeingValidated);
            double number = double.Parse(possibleDouble);
            ValidatePositiveDouble(number, fieldBeingValidated);
            return number;
        }
        public static void ValidateGenderType(string inputGender)
        {
            string validGenderTypes = string.Join(", ", Enum.GetNames(typeof(GenderType)));
            if (Enum.IsDefined(typeof(GenderType), inputGender) == false)
            {
                throw new ArgumentException($"Please input a valid gender type out of the following: {validGenderTypes}!");
            }
        }
        public static GenderType ParseGenderType(string inputGender)
        {
            ValidateGenderType(inputGender);
            var genderType = Enum.Parse<GenderType>(inputGender, true);
            return genderType;
        }        
        public static void ValidateCommandType(string inputCommand)
        {
            string validCommandTypes = string.Join(", ", Enum.GetNames(typeof(CosmeticsCommandType)));            
            if (Enum.IsDefined(typeof(CommandType), inputCommand) == false)
            {
                throw new ArgumentException($"Please input a valid command out of the following: {validCommandTypes}!");
            }
        }
        public static CosmeticsCommandType ParseCommandType(string inputCommand)
        {
            ValidateCommandType(inputCommand);
            var commandType = Enum.Parse<CosmeticsCommandType>(inputCommand, true);        
            return commandType;
        }
        public static void ValidateArgumentsCount(int correctCount, string[] arguments, string commandName)
        {
            if (arguments.Length != correctCount)
            {
                throw new ArgumentsCountException($"The {commandName} command requires {correctCount} arguments!");
            }
        }
    }
}
