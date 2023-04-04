
using static Dealership.Validator;
using static Dealership.UtilityMethods;
using static Dealership.PrintingHelpers;
using Dealership.Models.Contracts;
using System.Text;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;

        private string content;
        private string author;
        
        public Comment(string content, string author)
        {
            this.Content= content;
            this.Author= author;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                string className = this.GetType().Name;
                string propertyName = GetMethodName();
                ValidateStringPropertyLength(value, className, propertyName, CommentMinLength, CommentMaxLength);
                this.content = value; 
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                //Already validated through UserName anyway
                string errorMessage = "The comment's Author must be an actual word";
                ValidateStringNotNullOrEmpty(value, errorMessage);
                this.author = value;
            }
        }

        public IComment Clone()
        {
            return (IComment)this.MemberwiseClone();
        }

        public override bool Equals(object comment)
        {
            bool areEqual = false;
            var comparedComment = comment as IComment;
            if (comparedComment == null)
            {
                return areEqual;
            }
            if (comparedComment.Author == this.Author
                && comparedComment.Content == this.Content)
            {
                areEqual = true;
            }
            return areEqual;
        }

        public string Print()
        {
            var commentInfo = new StringBuilder();
            string contentSeperator = CreateCommentSeperator();
            string commentIdentation = CreateIndentation(CommentIndentationLevel);
            commentInfo.AppendLine(commentIdentation + contentSeperator);
            commentInfo.AppendLine(commentIdentation + $"{this.Content}");
            string authorIdentation = CreateIndentation(CommentAuthorIndentationLevel);
            commentInfo.AppendLine(authorIdentation + $"User: {this.Author}");
            commentInfo.Append(commentIdentation + contentSeperator);
            return commentInfo.ToString();
        }
    }
}
