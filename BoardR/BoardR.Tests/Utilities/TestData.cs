using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Tests.Utilities
{
    internal class BoardItemData
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 30;
        public string shorterTitle = string.Format("x", TitleMinLength - 1);
        public string longerTitle = string.Format("x", TitleMinLength + 1);
        public DateTime validDate = DateTime.Now.AddDays(1);
        public DateTime invalidDate = DateTime.Now.AddDays(-1);
    }
    internal class TaskData
    {
        public const int AssigneeMinLength = 5;
        public const int AssigneeMaxLength = 30;
        public string shorterAssigneeName = string.Format("x", AssigneeMinLength - 1);
        public string LongerAssigneeName = string.Format("x", AssigneeMaxLength + 1);
        public const ItemStatus TaskMinStatus = ItemStatus.ToDo;
        public const ItemStatus TaskMaxStatus = ItemStatus.Verified;
    }
    internal static class IssueData
    {        
        public const ItemStatus IssueMinStatus = ItemStatus.Open;
        public const ItemStatus IssueMaxStatus = ItemStatus.Verified;
    }
}
