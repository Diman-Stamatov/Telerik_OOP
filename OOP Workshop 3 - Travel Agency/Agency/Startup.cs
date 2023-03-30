using Agency.Core;
using Agency.Core.Contracts;
using Agency.Models;
using System.ComponentModel.DataAnnotations;

namespace Agency
{
    class Startup
    {
        static void Main()
        {
            /*IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Engine(commandFactory);
            engine.Start();*/
            var train = new Train(2, 40, 2.1, 7);
            var trainTwo = train.Copy();
            System.Console.WriteLine(train.ToString());
            System.Console.WriteLine(trainTwo.ToString());

        }
    }
}
