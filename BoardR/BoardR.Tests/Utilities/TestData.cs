using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Tests.Utilities
{
    
    public  static class BoardItemData
    {
        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 30;    
    }
    public static class TaskData
    {
        public const int AssigneeMinLength = 5;
        public const int AssigneeMaxLength = 30;
        
        public const ItemStatus TaskMinStatus = ItemStatus.ToDo;
        public const ItemStatus TaskMaxStatus = ItemStatus.Verified;
    }
    public static class IssueData
    {        
        public const ItemStatus IssueMinStatus = ItemStatus.Open;
        public const ItemStatus IssueMaxStatus = ItemStatus.Verified;
        public const string DefaultDescription = "No description";
    }

    public static class HelperValues
    {
        public static string GetTestString(int size)
        {
            return new string('x', size);
        }
        
        public static DateTime ValidDate = DateTime.Now.AddDays(1);
        public static DateTime InvalidDate = DateTime.Now.AddDays(-1);
        
        
    }
}
