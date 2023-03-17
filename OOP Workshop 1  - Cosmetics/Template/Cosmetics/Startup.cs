using System;
using System.Collections.Generic;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;

namespace Cosmetics
{
    public class Startup
    {
        public static void Main()
        {

            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine cosmeticsEngine = new Engine(commandFactory);
            cosmeticsEngine.Start();


        }
    }
}
