using CosmeticsShop.ApplicationErrors;
using CosmeticsShop.Core;
using CosmeticsShop.Helpers;
using CosmeticsShop.Models;
using System;
using static CosmeticsShop.Helpers.ValidationHelpers;
using CosmeticsShop.Enums;

namespace CosmeticsShop
{
    class StartUp
    {
        public static void Main()
        {
            
            Engine engine = new Engine();
            engine.Start();

        }
    }
}
