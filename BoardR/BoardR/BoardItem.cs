using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using static BoardR.ValidationHelpers;

namespace BoardR
{

    internal class BoardItem
    {
        
        private string title;
        private DateTime dueDate;
        private ItemStatus status;
        private List<EventLog> events = new List<EventLog>();

        public string Title
        {
            get
            {
                return this.title;
            }
              set
            {
                ValidateTitle(value);
                if (this.title != null)
                {
                    string eventMessage = GenerateEventMessage(nameof(Title), this.Title, value);
                    CreateEvent(eventMessage);
                }
                

                this.title = value;
            }
        }        
        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
             set
            {
                ValidateDueDate(value);
                if (this.dueDate != DateTime.MinValue)
                {
                    string eventMessage = GenerateEventMessage(nameof(DueDate), this.dueDate, value);
                    CreateEvent(eventMessage);
                }
                

                this.dueDate = value;
                               
                
            }
        }
        public ItemStatus Status
            {
                 get 
                 { 
                     return this.status;
                 }
            }

        public BoardItem(string title, DateTime dueDate)
        {
            this.Title = title;
            this.DueDate = dueDate;
            this.status = 0;
            

            string eventMessage = GenerateEventMessage(title, this.Status, dueDate);
            CreateEvent(eventMessage);
            
            
        }
        
        
        public void RevertStatus()
        {
            int minStatusIndex = 0;
            int currentStatusIndex = (int)this.status;
            if (currentStatusIndex != minStatusIndex)
            {
                
                this.status--;
                string eventMessage = GenerateEventMessage(this.Status, minStatusIndex);
                CreateEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(minStatusIndex);
                CreateEvent(eventMessage);
            }
        }
        public void AdvanceStatus()
        {
            int maxStatusIndex = Enum.GetNames(typeof(ItemStatus)).Length -1;
            int currentStatusIndex = (int)this.status;
            if (currentStatusIndex < maxStatusIndex)
            {
                this.status++;
                string eventMessage = GenerateEventMessage(this.Status, maxStatusIndex);
                CreateEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(maxStatusIndex);
                CreateEvent(eventMessage);
            }
        }

        public string ViewInfo()
        {
            return $"'{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }
        public string ViewHistory()
        {
            var historyLog = new StringBuilder();
            int numberOfEvents = events.Count;
            for (int loggedEvent = 0; loggedEvent < numberOfEvents; loggedEvent++)
            {
                var currentEvent = events[loggedEvent];
                historyLog.Append(currentEvent.ViewInfo());
                if (loggedEvent !=numberOfEvents -1)
                {
                    historyLog.Append("\n");
                }
            }
            return historyLog.ToString();
        }

        private void CreateEvent(string message)
        {
            var newEvent = new EventLog(message);
            events.Add(newEvent);
        }
        private string GenerateEventMessage(string propertyName, string oldValue, string newValue)
        {
            string creationMessage = $"{propertyName} changed from '{oldValue}' to '{newValue}'";
            return creationMessage;
        }
        private string GenerateEventMessage(string propertyName, DateTime oldValue, DateTime newValue)
        {
            string creationMessage = $"{propertyName} changed from '{oldValue.ToString("dd-MM-yyyy")}' to '{newValue.ToString("dd-MM-yyyy")}'";
            return creationMessage;
        }
        private string GenerateEventMessage(string title, ItemStatus status, DateTime dueDate)
        {
            string creationMessage = $"Item created: '{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
            return creationMessage;
        }
        private string GenerateEventMessage(ItemStatus status, int IndexConstraint)
        {
            string creationMessage = "";
            if (IndexConstraint == 0)
            {
                creationMessage = $"Status changed from {this.Status + 1} to {this.Status}";
            }
            else
            {
                creationMessage = $"Status changed from {this.Status-1} to {this.Status}";
            }            
            return creationMessage;
        }
        private string GenerateEventMessage(int IndexConstraint)
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
