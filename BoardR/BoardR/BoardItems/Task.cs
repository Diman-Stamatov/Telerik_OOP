using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardR.ValidationHelpers;
using static BoardR.EventMessageGenerator;


namespace BoardR
{
    internal class Task : BoardItem
    {
        private const int AssigneeMinLength = 5;
        private const int AssigneeMaxLength = 30;

        private string assignee;
        
        public string Assignee
        {
            get 
            { 
                return this.assignee; 
            }
            set 
            {
                string propertyName = GetPropertyName();
                ValidateStringProperty(value, propertyName, AssigneeMinLength, AssigneeMaxLength);
                if (assignee != null)
                {
                    string eventMessage = GenerateEventMessage(propertyName, Assignee, value);
                    LogEvent(eventMessage);
                }                
                this.assignee = value; 

            }
        }
        
        public Task (string title, string assignee, DateTime dueDate ) : base (title, dueDate)
        {
            this.Assignee = assignee;
            this.minimumStatus = ItemStatus.ToDo;

            this.status = this.minimumStatus;

            string itemName = this.GetType().Name;
            string eventMessage = GenerateEventMessage(itemName, title, Status, dueDate);
            LogEvent(eventMessage);


        }

        public override void AdvanceStatus()
        {
            if (status <maximumStatus)
            {
                status++;
                string callerName = this.GetType().Name;
                string eventMessage = GenerateEventMessage(Status, maximumStatus, callerName);
                LogEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(maximumStatus);
                LogEvent(eventMessage);
            }
        }
        public override void RevertStatus()
        {
            if (status != minimumStatus)
            {
                status--;
                string callerName = this.GetType().Name;
                string eventMessage = GenerateEventMessage(Status, minimumStatus, callerName);
                LogEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateEventMessage(minimumStatus);
                LogEvent(eventMessage);
            }
        }

        
    }
}
