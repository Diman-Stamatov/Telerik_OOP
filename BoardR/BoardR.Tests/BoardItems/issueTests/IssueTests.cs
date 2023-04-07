using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR.BoardItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardR.Tests.BoardItems.IssueTests

{
    [TestClass]
    public class IssueTests
    {
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
