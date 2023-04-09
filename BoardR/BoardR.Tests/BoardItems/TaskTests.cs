using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardR.Tests.BoardItems
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Task_Should_DeriveFromBoardItem()
        {
            var type = typeof(Task);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable, "Task does not inherit BoardItem!");
        }

        [TestMethod]
        [DataRow(TitleMaxLength + 1)]
        [DataRow(TitleMaxLength + 2)]
        [DataRow(TitleMinLength - 1)]
        [DataRow(TitleMinLength - 2)]
        public void Task_ShouldThrow_WhenTitleIsInvalidLength(int testSize)
        {
            string testTitle = GetTestString(testSize);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(testTitle, validAssignee, ValidDate));
        }

        [TestMethod]
        [DataRow(AssigneeMaxLength + 1)]
        [DataRow(AssigneeMaxLength + 2)]
        [DataRow(AssigneeMinLength - 1)]
        [DataRow(AssigneeMinLength - 2)]
        public void Task_ShouldThrow_WhenAssigneeIsInvalidLength(int testSize)
        {
            string validTitle = GetTestString(TitleMaxLength);
            string testAssignee = GetTestString(testSize);

            Assert.ThrowsException<ArgumentException>(() =>
            new Task(validTitle, testAssignee, ValidDate));
        }

        [TestMethod]
        public void Task_ShouldThrow_WhenDueDateIsInvalid()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Assert.ThrowsException<ArgumentException>(() =>
            new Task(validTitle, validAssignee, InvalidDate));
        }

        [TestMethod]
        public void Task_Should_CreateWhenAllDataIsValid()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task task = new Task(validTitle, validAssignee, ValidDate);

            Assert.IsNotNull(task);
        }

        [TestMethod]
        public void Task_AdvanceStatus_Should_SetToNextStatus()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task task = new Task(validTitle, validAssignee, ValidDate);
            task.AdvanceStatus();

            Assert.AreEqual(TaskMinStatus + 1, task.Status);
        }

        [TestMethod]
        public void Task_AdvanceStatus_ShouldNot_AdvancePastVerified()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task task = new Task(validTitle, validAssignee, ValidDate);
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();

            Assert.AreEqual(TaskMaxStatus, task.Status);
        }

        [TestMethod]
        public void Task_RevertStatus_Should_SetToPreviousStatus()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task task = new Task(validTitle, validAssignee, ValidDate);
            task.AdvanceStatus();
            task.RevertStatus();

            Assert.AreEqual(TaskMinStatus, task.Status);
        }

        [TestMethod]
        public void Task_RevertStatus_ShouldNot_RevertPastToDo()
        {
            string validTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task task = new Task(validTitle, validAssignee, ValidDate);
            task.AdvanceStatus();
            task.RevertStatus();
            task.RevertStatus();

            Assert.AreEqual(TaskMinStatus, task.Status);
        }

        [TestMethod]
        public void Task_Equals_Should_CompareItemsWithTheSameDataAsEqual()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validAssignee = GetTestString(AssigneeMaxLength);

            Task taskOne = new Task(testTitle, validAssignee, ValidDate);
            Task taskTwo = new Task(testTitle, validAssignee, ValidDate);


            Assert.IsTrue(taskOne.Equals(taskTwo));
        }
    }
}
