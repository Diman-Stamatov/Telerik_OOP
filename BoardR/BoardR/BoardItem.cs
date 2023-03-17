using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR;
using Microsoft.VisualBasic;
using static BoardR.ValidationHelpers;

namespace BoardR
{

    internal class BoardItem
    {
        
        private string title;
        private DateTime dueDate;
        private ItemStatus status;

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                ValidateTitle(value);
                this.title = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            private set
            {
                ValidateDueDate(value);
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
        }
        
        
        public void RevertStatus()
        {
            int minStatusIndex = 0;
            int currentStatusIndex = (int)this.status;
            if (currentStatusIndex != minStatusIndex)
            {
                this.status--;
            }
        }
        public void AdvanceStatus()
        {
            int maxStatusIndex = Enum.GetNames(typeof(ItemStatus)).Length -1;
            if ((int)this.status < maxStatusIndex)
            {
                this.status++;
            }
        }

        public string ViewInfo()
        {
            return $"'{title}', [{status}|{dueDate.ToString("dd-MM-yyyy")}]";
        }
        
    }
}
