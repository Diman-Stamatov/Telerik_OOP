using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Contracts
{
    public interface ICopyable
    {
        IVehicle Copy();

    }
}
