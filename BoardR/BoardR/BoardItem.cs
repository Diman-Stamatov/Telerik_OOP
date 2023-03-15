using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR;

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
                if (value == null || TitleIsValid(value) == false)
                {
                    throw new ArgumentException("Please specify a title that is between 5 and 30 characters long!");
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
            private set
            {
                var creationDate = DateTime.Now;
                if (creationDate > value)
                {
                    throw new ArgumentException("The due date cannot be in the past!");
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
        }
        private bool TitleIsValid(string value)
        {

            bool titleIsValid = true;
            if (value == null)
            {
                titleIsValid = false;
            }
            int newTitleLength = value.Length;
            int minimumTitleLength = 5;
            int maximumTitleLength = 30;
            if (newTitleLength < minimumTitleLength || newTitleLength > maximumTitleLength)
            {
                titleIsValid = false;
            }
            return titleIsValid;




        }
        public void RevertStatus()
        {
            if (this.status !=0)
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
