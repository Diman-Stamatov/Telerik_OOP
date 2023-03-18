using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR
{
    internal static class EventMessageGenerator
    {
        public static string GenerateEventMessage(string propertyName, string oldValue, string newValue)
        {
            string creationMessage = $"{propertyName} changed from '{oldValue}' to '{newValue}'";
            return creationMessage;
        }
        public static string GenerateEventMessage(string propertyName, DateTime oldValue, DateTime newValue)
        {
            string creationMessage = $"{propertyName} changed from '{oldValue.ToString("dd-MM-yyyy")}' to '{newValue.ToString("dd-MM-yyyy")}'";
            return creationMessage;
        }
        public static string GenerateEventMessage(string title, ItemStatus status, DateTime dueDate)
        {
            string creationMessage = $"Item created: '{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
            return creationMessage;
        }
        public static string GenerateEventMessage(ItemStatus status, int IndexConstraint)
        {
            string creationMessage = "";
            if (IndexConstraint == 0)
            {
                creationMessage = $"Status changed from {status + 1} to {status}";
            }
            else
            {
                creationMessage = $"Status changed from {status - 1} to {status}";
            }
            return creationMessage;
        }
        public static string GenerateEventMessage(int IndexConstraint)
        {
            string creationMessage = "";
            if (IndexConstraint == 0)
            {
                creationMessage = $"Unable to revert the status any further!";
            }
            else
            {
                creationMessage = $"Unable to advance the status any further!";
            }
            return creationMessage;
        }
    }
}
