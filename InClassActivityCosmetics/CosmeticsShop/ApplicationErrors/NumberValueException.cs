using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.ApplicationErrors
{
    internal class NumberValueException : ApplicationException 
    {
        public NumberValueException(string message) : base(message)
        { }
    }
}
