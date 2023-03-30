using Agency.Core;
using Agency.Core.Contracts;
using Agency.Models;
using Agency.Models.Contracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agency
{
    class Startup
    {
        static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Engine(commandFactory);
            engine.Start();





        }
    }
}
