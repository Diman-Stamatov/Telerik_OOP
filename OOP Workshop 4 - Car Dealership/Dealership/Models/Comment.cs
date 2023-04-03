
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Comment : IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";
        
        public Comment(string content, string author)
        {

        }
        public string Content => throw new System.NotImplementedException();

        public string Author => throw new System.NotImplementedException();

        //ToDo
    }
}
