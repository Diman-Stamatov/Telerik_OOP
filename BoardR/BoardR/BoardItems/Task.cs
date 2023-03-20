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
                    string eventMessage = GenerateEventMessage(propertyName, Title, value);
                    CreateItemEvent(eventMessage);
                }
                this.assignee = value; 

            }
        }
        
        public Task (string title, string assignee, DateTime dueDate ) : base (title, dueDate)
        {
            this.Assignee = assignee;
            this.status = ItemStatus.ToDo;    
        }        
        
    }
}
