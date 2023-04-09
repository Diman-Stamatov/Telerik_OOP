using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoardR.BoardItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardR.Tests.BoardItems
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

        [TestMethod]
        [DataRow(TitleMaxLength + 1)]
        [DataRow(TitleMaxLength + 2)]
        [DataRow(TitleMinLength - 1)]
        [DataRow(TitleMinLength - 2)]
        public void Issue_ShouldThrow_WhenTitleIsInvalidLength(int testSize)
        {
            string testTitle = GetTestString(4);
            string validDescription = GetTestString(1);

            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(testTitle, validDescription, ValidDate));
        }

        [TestMethod]
        
        public void Issue_Should_SetDefaultDescriptionIfNullOrEmpty()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = string.Empty;

            var issue = new Issue(testTitle, validDescription, ValidDate);

            Assert.AreEqual(issue.Description, DefaultDescription); 
            
        }


        [TestMethod]        
        public void Issue_ShouldThrow_WhenDueDateIsInvalid()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(testTitle, validDescription, InvalidDate));
        }

        [TestMethod]
        public void Issue_Should_CreateWhenAllDataIsValid()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);

            Assert.IsNotNull(issue);
        }

        [TestMethod]
        public void Issue_AdvanceStatus_Should_SetToVerified()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);
            issue.AdvanceStatus();

            Assert.AreEqual(IssueMaxStatus, issue.Status);
        }
        [TestMethod]
        public void Issue_AdvanceStatus_ShouldNot_AdvanceFurtherThanVerified()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);
            issue.AdvanceStatus();
            issue.AdvanceStatus();

            Assert.AreEqual(IssueMaxStatus, issue.Status);
        }

        [TestMethod]
        public void Issue_RevertStatus_Should_SetToOpen()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);
            issue.AdvanceStatus();
            issue.RevertStatus();

            Assert.AreEqual(IssueMinStatus, issue.Status);
        }
        [TestMethod]
        public void Issue_RevertStatus_ShouldNot_RevertFurtharThanOpen()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);            
            issue.RevertStatus();

            Assert.AreEqual(IssueMinStatus, issue.Status);
        }

        [TestMethod]
        public void Issue_Equals_Should_CompareItemsWithTheSameDataAsEqual()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issueOne = new Issue(testTitle, validDescription, ValidDate);
            Issue issueTwo = new Issue(testTitle, validDescription, ValidDate);
            

            Assert.IsTrue(issueOne.Equals(issueTwo));
        }

        [TestMethod]
        public void Issue_ViewInfo_Should_ReturnAStringWithItemInformation()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);
           string issueInfo = issue.ViewInfo();

            Assert.IsTrue(string.IsNullOrEmpty(issueInfo) == false);
        }

        [TestMethod]
        public void Issue_ViewHistory_Should_ReturnAStringWithItemInformation()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);

            Issue issue = new Issue(testTitle, validDescription, ValidDate);
            string issueHistory = issue.ViewHistory();

            Assert.IsTrue(string.IsNullOrEmpty(issueHistory) == false);
        }
    }
}
