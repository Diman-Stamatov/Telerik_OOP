using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership
{
    internal class PrintingHelpers
    {
        private const int IdentationSize = 2;
        private const int CommentSeperatorLength = 10;

        public const int VehicleIdentationLevel = 1;
        public const int CommentIdentationLevel = 2;
        public const int CommentAuthorIdentationLevel = 3;
        public const string VehiclePrintHeader = "{0}. {1}:";
        public const string CommentPrintHeader = "--COMMENTS--";
        public const string NoCommentsPrintMessage = "--NO COMMENTS--";
        public const string UserPrintHeader = "--USER {0}--";
        public static string CreateIdentation(int identationLevel)
        {
            return new string(' ', IdentationSize * identationLevel);
        }
        public static string CreateCommentSeperator()
        {
            return new string('-', CommentSeperatorLength);
        }

    }
}
