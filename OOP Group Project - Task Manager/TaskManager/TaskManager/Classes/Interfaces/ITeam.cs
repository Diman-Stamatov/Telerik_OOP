using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Classes.Interfaces
{
    internal interface ITeam
    {
        string Name { get; }
        IEnumerable<Member> Members { get; }
        IEnumerable<Board> Boards { get; }

    }
}
