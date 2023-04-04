using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership
{
    internal class PrintingHelpers
    {
        private const int IndentationSize = 2;
        private const int CommentSeperatorLength = 10;

        public const int VehicleIndentationLevel = 1;
        public const int CommentIndentationLevel = 2;
        public const int CommentAuthorIndentationLevel = 3;
        public const string VehiclePrintHeader = "{0}. {1}:";
        public const string CommentPrintHeader = "--COMMENTS--";
        public const string NoCommentsPrintMessage = "--NO COMMENTS--";
        public const string UserPrintHeader = "--USER {0}--";
        public const string ShowUsersPrintHeader = "--USERS--";
        public static string CreateIndentation(int identationLevel)
        {
            return new string(' ', IndentationSize * identationLevel);
        }
        public static string CreateCommentSeperator()
        {
            return new string('-', CommentSeperatorLength);
        }

    }
}
