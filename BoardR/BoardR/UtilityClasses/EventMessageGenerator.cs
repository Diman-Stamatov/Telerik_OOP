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
            string eventMessage = $"{propertyName} changed from '{oldValue}' to '{newValue}'";
            return eventMessage;
        }
        public static string GenerateEventMessage(string propertyName, DateTime oldValue, DateTime newValue)
        {
            string eventMessage = $"{propertyName} changed from '{oldValue.ToString("dd-MM-yyyy")}' to '{newValue.ToString("dd-MM-yyyy")}'";
            return eventMessage;
        }
        public static string GenerateEventMessage(string itemName, string title, ItemStatus status, DateTime dueDate)
        {
            string eventMessage = $"{itemName} created: '{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
            return eventMessage;
        }
        public static string GenerateEventMessage(string itemName, string title, ItemStatus status, DateTime dueDate, string description)
        {
            string eventMessage = $"{itemName} created: '{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]. Description: {description}";
            return eventMessage;
        }
        public static string GenerateEventMessage(ItemStatus status, ItemStatus statusConstraint, string callerName)
        {
            string eventMessage;
            ItemStatus newStatus;
            
            if (statusConstraint == ItemStatus.Verified)
            {

                if (callerName == "Issue")
                {
                    eventMessage = $"Status changed from {ItemStatus.Open} to {ItemStatus.Verified}";
                }
                else
                {
                    eventMessage = $"Status changed from {status - 1} to {status}";
                }
            }
            else
            {
                if (callerName == "Issue")
                {
                    eventMessage = $"Status changed from {ItemStatus.Verified} to {ItemStatus.Open}";
                }
                else
                {
                    eventMessage = $"Status changed from {status + 1} to {status}";
                }
                
            }
            return eventMessage;
        }
        public static string GenerateEventMessage(ItemStatus statusConstraint)
        {
            string eventMessage;
            
            if (statusConstraint == ItemStatus.Verified)
            {
                eventMessage = $"Unable to advance the status any further!";
                
            }
            else
            {
                eventMessage = $"Unable to revert the status any further!";
            }
            return eventMessage;
        }
    }
}
