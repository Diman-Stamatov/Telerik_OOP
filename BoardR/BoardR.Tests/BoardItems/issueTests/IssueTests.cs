using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR.BoardItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BoardR.Tests.Utilities.TestData;

namespace BoardR.Tests.BoardItems.IssueTests

{
    [TestClass]
    public class IssueTests
    {
        [ClassInitialize]
        public static void ClassInitialize()
        {
            public string shorterTitle = string.Format("x", TitleMinLength - 1);
        public string longerTitle = string.Format("x", TitleMinLength + 1);
        public DateTime validDate = DateTime.Now.AddDays(1);
        public DateTime invalidDate = DateTime.Now.AddDays(-1);
        public string shorterAssigneeName = string.Format("x", AssigneeMinLength - 1);
        public string LongerAssigneeName = string.Format("x", AssigneeMaxLength + 1);
    }
        [TestMethod]
        public void Issue_Should_DeriveFromBoardItem()
        {
            var type = typeof(Issue);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);
            
            Assert.IsTrue(isAssignable, "Issue does not inherit BoardItem!");
        }

        public void Issue_ShouldThrow_WhenTitleIsTooLong()
        {
            Assert.ThrowsException<ArgumentException>(()=>
            new Issue(BoardItemData.)
        }
    }
}
