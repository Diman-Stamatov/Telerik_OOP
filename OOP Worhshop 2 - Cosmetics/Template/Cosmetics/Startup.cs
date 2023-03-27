using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics
{
    public class Startup
    {
        static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine cosmeticsEngine = new Engine(commandFactory);
            cosmeticsEngine.Start();

            /*string[] CommandParameters = Console.ReadLine().Split(' ');
            string shampooName = CommandParameters[0];
            string shampooBrand = CommandParameters[1];
            decimal price = Decimal.Parse(CommandParameters[2]);
            GenderType genderType = (GenderType)Enum.Parse(typeof(GenderType), CommandParameters[3]);
            ScentType scentType = (ScentType)Enum.Parse(typeof(ScentType), CommandParameters[4]);

            var cream = new Cream(shampooName, shampooBrand, price, genderType, scentType);
            Console.WriteLine(cream.Name);
            Console.WriteLine(cream.Brand);
            Console.WriteLine(cream.Price);
            Console.WriteLine(cream.Gender);
            Console.WriteLine(cream.Scent);*/
        }
    }
}
