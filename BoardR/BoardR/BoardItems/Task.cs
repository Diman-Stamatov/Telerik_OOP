using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BoardR.ValidationHelpers;
using static BoardR.EventMessageGenerator;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BoardR.Tests")]
namespace BoardR
{
    internal class Task : BoardItem
    {
        public const int AssigneeMinLength = 5;
        public const int AssigneeMaxLength = 30;

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
        public override string ViewInfo()
        {
            string taskInfo = base.ViewInfo() + $" Assignee: {this.Assignee}";
            return taskInfo;
        }
        public override void AdvanceStatus()
        {
            if (status <maximumStatus)
            {
                string eventMessage = GenerateAdvanceStatusMessage();
                status++;
                LogEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateAdvanceStatusMessage();
                LogEvent(eventMessage);
            }
        }
        public override void RevertStatus()
        {
            if (status != minimumStatus)
            {


                string eventMessage = GenerateRevertStatusMessage();
                status--;
                LogEvent(eventMessage);
            }
            else
            {
                string eventMessage = GenerateRevertStatusMessage();
                LogEvent(eventMessage);
            }
        }
        public override string GenerateAdvanceStatusMessage()
        {
            string advanceStatusMessage;
            if (this.status != maximumStatus)
            {
                advanceStatusMessage = $"Status changed from {status} to {status+1}";
            }
            else
            {
                advanceStatusMessage = $"Unable to advance the status any further, it is already set to {maximumStatus}!";
            }
            return advanceStatusMessage;
        }
        public override string GenerateRevertStatusMessage()
        {
            string advanceStatusMessage;
            if (this.status != minimumStatus)
            {
                advanceStatusMessage = $"Status changed from {status} to {status-1}";
            }
            else
            {
                advanceStatusMessage = $"Unable to revert the status any further, it is already set to {minimumStatus}!";
            }
            return advanceStatusMessage;
        }
    }
}
