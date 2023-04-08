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
            if (string.IsNullOrEmpty(description) == true)
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
        public override string ViewInfo()
        {
            string taskInfo = base.ViewInfo() + $" Description: {this.Description}";
            return taskInfo;
        }
        public override void AdvanceStatus()
        {
            if (status < maximumStatus)
            {
                string eventMessage = GenerateAdvanceStatusMessage();
                status = ItemStatus.Verified;
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
                status = ItemStatus.Open;
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
                advanceStatusMessage = $"Status changed from {minimumStatus} to {maximumStatus}";
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
                advanceStatusMessage = $"Status changed from {maximumStatus} to {minimumStatus}";
            }
            else
            {
                advanceStatusMessage = $"Unable to revert the status any further, it is already set to {minimumStatus}!";
            }
            return advanceStatusMessage;
        }
    }
}
