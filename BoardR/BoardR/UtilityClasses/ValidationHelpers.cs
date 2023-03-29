using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoardR
{
    internal static class ValidationHelpers
    {
        public static void ValidateDueDate(DateTime dueDate)
        {
            DateTime creationDate = DateTime.Now;
            string errorMessage = "The due date cannot be in the past!";
            if (creationDate > dueDate)
            {
                throw new ArgumentException(errorMessage);
            }
        }
        public static void ValidateStringProperty(string value, string propertyName, int minimumLength, int maximumLength)
        {
             
            string errorMessage = $"Please specify a {propertyName} that is between {minimumLength} and {maximumLength} characters long!";
            if (value == null || value == string.Empty)
            {
                throw new ArgumentNullException(null, errorMessage);
            }

            int newProeprtyLength = value.Length;
            if (newProeprtyLength < minimumLength || newProeprtyLength > maximumLength)
            {
                throw new ArgumentException(errorMessage);
            }
        }        
        public static void ValidateEventDescription(string description)
        {
            string errorMessage = "Please specify an event description!";
            if (description == null)
            {
                throw new ArgumentNullException(null, errorMessage);
            }
        }

    }
}
