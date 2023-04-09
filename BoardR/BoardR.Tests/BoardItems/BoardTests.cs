using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Tests.BoardItems
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_AddItem_ShouldThrow_WhenItemIsNull()
        {
            BoardItem nullBoardItem = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
                        Board.AddItem(nullBoardItem));
        }

        [TestMethod]
        public void Board_AddItem_Should_AddItemWhenItemIsValid()
        {
            string validTitle = GetTestString(TitleMinLength) + "y";
            string validAssignee = GetTestString(AssigneeMaxLength);
            var task = new Task(validTitle, validAssignee, ValidDate);
            int currentItems = Board.TotalItems;
            Board.AddItem(task);

            Assert.AreEqual(currentItems + 1, Board.TotalItems);
        }

        [TestMethod]
        public void Board_AddItem_ShouldThrow_WhenItemIsDuplicate()
        {
            string validTitle = GetTestString(TitleMinLength+Board.TotalItems);
            string validAssignee = GetTestString(AssigneeMaxLength);
            var task = new Task(validTitle, validAssignee, ValidDate);
            Board.AddItem(task);
            Assert.ThrowsException<InvalidOperationException>(() =>
                        Board.AddItem(task));
        }

        

    }
}
