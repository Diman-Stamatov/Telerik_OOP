using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Tests.Utilities
{
    internal static class BoardItemData
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 30;
        
    }
    internal static class TaskData
    {
        public const int AssigneeMinLength = 5;
        public const int AssigneeMaxLength = 30;
        
        public const ItemStatus TaskMinStatus = ItemStatus.ToDo;
        public const ItemStatus TaskMaxStatus = ItemStatus.Verified;
    }
    internal static class IssueData
    {        
        public const ItemStatus IssueMinStatus = ItemStatus.Open;
        public const ItemStatus IssueMaxStatus = ItemStatus.Verified;
    }
}
