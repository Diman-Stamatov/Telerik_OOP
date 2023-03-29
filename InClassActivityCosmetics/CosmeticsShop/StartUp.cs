using CosmeticsShop.ApplicationErrors;
using CosmeticsShop.Core;
using static CosmeticsShop.Helpers.ValidationHelpers;

namespace CosmeticsShop
{
    class StartUp
    {
        public static void Main()
        {
            try
            {
                string price = "-1";
                ParsePrice(price);
            }
            catch (PriceValueException ex)
            {

                System.Console.WriteLine(ex.Message);
            }
            /*Engine engine = new Engine();
            engine.Start();*/

        }
    }
}
