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
        
    }
}
