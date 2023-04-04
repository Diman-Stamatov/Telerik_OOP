using Dealership.Core;
using Dealership.Core.Contracts;
using Dealership.Models;
using Dealership.Models.Contracts;
using System.Collections.Generic;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            /*IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();*/
            var cars = new List<IVehicle>(); 
            var car1 = new Car("Aston", "Martin", 500, 4);
            cars.Add(car1);
            var car2 = new Car("Aston", "Martin", 500, 4);
            int index = cars.IndexOf(car2);
            System.Console.WriteLine(index);
        }
    }
}
