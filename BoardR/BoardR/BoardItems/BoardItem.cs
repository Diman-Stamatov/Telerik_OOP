using BoardR.BoardItems;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static BoardR.EventMessageGenerator;
using static BoardR.ValidationHelpers;
using static System.Net.Mime.MediaTypeNames;

namespace BoardR
{

    internal abstract class BoardItem
    {
        private const int TitleMinLength = 5;
        private const int TitleMaxLength = 30;
        

        private protected ItemStatus minimumStatus;
        private protected ItemStatus maximumStatus = ItemStatus.Verified;
        

        private string title;
        private DateTime dueDate;
        private protected ItemStatus status;
        private protected List<EventLog> events;

       
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                string propertyName = GetPropertyName();
                ValidateStringProperty(value, propertyName, TitleMinLength, TitleMaxLength);
                if (title != null)
                {       
                    string eventMessage = GenerateEventMessage(propertyName, Title, value);
                    LogEvent(eventMessage);
                }
                
                title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }

            set
            {
                ValidateDueDate(value);
                if (DueDate != DateTime.MinValue)
                {       
                    string propertyName = GetPropertyName();
                    string eventMessage = GenerateEventMessage(propertyName, dueDate, value);
                    LogEvent(eventMessage);
                }
                
                dueDate = value;
            }
        }
        public ItemStatus Status
        {
            get
            {
                return status;
            }
        }

        public BoardItem(string title, DateTime dueDate)
        {
            this.events = new List<EventLog>();
            this.Title = title;
            this.DueDate = dueDate;
        }

       
        public virtual string ViewInfo()
        {
            return $"'{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }
        public string ViewHistory()
        {
            var historyLog = new StringBuilder();
            int numberOfEvents = this.events.Count;
            for (int loggedEvent = 0; loggedEvent < numberOfEvents; loggedEvent++)
            {
                var currentEvent = this.events[loggedEvent];
                historyLog.Append(currentEvent.ViewInfo());
                if (loggedEvent != numberOfEvents - 1)
                {
                    historyLog.Append("\n");
                }
            }
            return historyLog.ToString();
        }

        private protected void LogEvent(string message)
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
            if (Title == item.Title
                && DueDate == item.DueDate)
            {
                isEqual = true;
            }
            return isEqual;
        }
        public abstract void AdvanceStatus();
        public abstract void RevertStatus();

        public abstract string GenerateAdvanceStatusMessage();
        public abstract string GenerateRevertStatusMessage();
    }
}
