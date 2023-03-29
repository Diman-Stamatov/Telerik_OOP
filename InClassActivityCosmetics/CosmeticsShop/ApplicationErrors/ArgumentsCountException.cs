using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.ApplicationErrors
{
    internal class ArgumentsCountException : ApplicationException
    {
        public ArgumentsCountException(string message) : base(message)
        { }
    }
}
