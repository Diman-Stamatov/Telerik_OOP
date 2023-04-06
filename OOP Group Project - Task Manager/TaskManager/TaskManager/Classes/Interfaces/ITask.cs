using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes.Interfaces
{
    internal interface ITask
    {
        string Title { get; }
        string Description { get; }

        IEnumerable<string> Comments { get; }
        IEnumerable<string> ChangeLog { get; }


    }
}
