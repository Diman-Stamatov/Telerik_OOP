using CosmeticsShop.ApplicationErrors;
using CosmeticsShop.Core;
using CosmeticsShop.Helpers;
using CosmeticsShop.Models;
using System;
using static CosmeticsShop.Helpers.ValidationHelpers;

namespace CosmeticsShop
{
    class StartUp
    {
        public static void Main()
        {
            
            try
            {
                var product = new Product("name", "Brand", 2, GenderType.Men);
                var productTwo = product.Clone();
                product.Name = "NewName";
                Console.WriteLine(productTwo.Name);
                Console.WriteLine(productTwo.Brand);
                Console.WriteLine(productTwo.Price);
                Console.WriteLine(productTwo.Gender);
            }
            catch (Exception ex)
            {

                System.Console.WriteLine(ex.Message);
            }
            /*Engine engine = new Engine();
            engine.Start();*/

        }
    }
}
