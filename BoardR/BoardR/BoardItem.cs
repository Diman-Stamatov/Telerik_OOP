using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using static BoardR.EventMessageGenerator;
using static System.Net.Mime.MediaTypeNames;
using static BoardR.Helpers.ValidationHelpers;

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

                    string propertyName = GetPropertyName();
                    string eventMessage = GenerateEventMessage(propertyName, this.Title, value);
                    CreateItemEvent(eventMessage);
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
                    string propertyName = GetPropertyName();
                    string eventMessage = GenerateEventMessage(propertyName, this.dueDate, value);
                    CreateItemEvent(eventMessage);
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
            CreateItemEvent(eventMessage);
            
            
        }        
        
        public void RevertStatus()
        {
            int minStatusIndex = 0;
            int currentStatusIndex = (int)this.status;
            if (currentStatusIndex != minStatusIndex)
            {
                
                this.status--;
                string eventMessage = GenerateEventMessage(this.Status, minStatusIndex);
                CreateItemEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(minStatusIndex);
                CreateItemEvent(eventMessage);
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
                CreateItemEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(maxStatusIndex);
                CreateItemEvent(eventMessage);
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

        private void CreateItemEvent(string message)
        {
            var newEvent = new EventLog(message);
            events.Add(newEvent);
        }        

        public string GetPropertyName([CallerMemberName] string methodName = null)
        {
           return methodName;
        }

        public bool Equals(BoardItem item)
        {
            bool isEqual = false;
            if (item == null)
            {
                return isEqual;
            }

            if (this == item)
            {
                isEqual = true;
            }
            if (this.Title == item.Title 
                && this.DueDate == item.DueDate)
            {
                isEqual = true;
            }
            return isEqual;
        }
    }
}
