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
    internal class IssueTests
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
            string testTitle = GetTestString(testSize);
            string validDescription = GetTestString(1);

            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(testTitle, validDescription, ValidDate));
        }
        [TestMethod]
        
        public void Issue_ShouldSetDefaultDescriptionIfNullOrEmpty()
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
        public void Issue_ShouldCreateWhenAllDataIsValid()
        {
            string testTitle = GetTestString(TitleMinLength);
            string validDescription = GetTestString(1);
            Issue issue = new Issue(testTitle, validDescription, ValidDate);

            Assert.IsNotNull(issue);
        }

    }
}
