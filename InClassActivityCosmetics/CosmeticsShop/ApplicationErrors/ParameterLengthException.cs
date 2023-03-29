using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.ApplicationErrors
{
    internal class ParameterLengthException : ApplicationException
    {
        public ParameterLengthException(string message) : base(message) 
        { }
    }
}
