using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardR.ValidationHelpers;
using static BoardR.EventMessageGenerator;

namespace BoardR
{
    internal class Issue : BoardItem
    {
        private readonly string description;
        public string Description
        {
            get 
            { 
                return this.description;
            }
            
        }
        public Issue(string title, string description, DateTime dueDate) : base(title, dueDate)
        {
            if (description == null)
            {
                this.description = "No description";
            }
            else
            {
                this.description = description;
            }
            this.minimumStatus = ItemStatus.Open;
            this.status = minimumStatus;
            
            string itemName = this.GetType().Name;
            string eventMessage = GenerateEventMessage(itemName, title, Status, dueDate, Description);
            
            LogEvent(eventMessage);
        }
        public override void AdvanceStatus()
        {
            if (status < maximumStatus)
            {
                status++;
                string eventMessage = GenerateEventMessage(Status, maximumStatus);
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
                string eventMessage = GenerateEventMessage(Status, minimumStatus);
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
