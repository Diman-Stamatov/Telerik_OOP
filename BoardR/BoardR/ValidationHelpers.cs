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
        public static void ValidateTitle(string value)
        {
            const int minimumTitleLength = 5;
            const int maximumTitleLength = 30;
            string errorMessage = $"Please specify a title that is between {minimumTitleLength} and {maximumTitleLength} characters long!";
            if (value == null)
            {
                throw new ArgumentNullException(null, errorMessage);
            }

            int newTitleLength = value.Length;

            if (newTitleLength < minimumTitleLength || newTitleLength > maximumTitleLength)
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
