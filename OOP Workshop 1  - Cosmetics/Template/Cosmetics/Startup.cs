using System;
using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;

namespace Cosmetics
{
    public class Startup
    {
        public static void Main()
        {
            var myMan = new Product("MyMan", "Nivea", 10.99, GenderType.Men);
            var shampoos = new Category("Shampoos");
            shampoos.AddProduct(myMan);
            var cart = new ShoppingCart();
            cart.AddProduct(myMan);
            Console.WriteLine(shampoos.Print());
            Console.WriteLine(cart.TotalPrice());
            shampoos.RemoveProduct(myMan);
            Console.WriteLine(shampoos.Print());
            cart.RemoveProduct(myMan);
            Console.WriteLine(cart.TotalPrice());

            




        }
    }
}
