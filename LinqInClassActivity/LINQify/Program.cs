using System;
using System.Collections.Generic;
using LINQify.Tasks;

namespace LINQify
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = Helper.GetData();

            //You can test your implementations here:

           var result1 = Task12.Execute(people);
           var result2 = Task12.ExecuteWithLINQ(people);

            for (int index = 0; index < result1.Count; index++)
            {
                Console.WriteLine($"Name: {result1[index].FirstName} Surname: {result1[index].LastName} " +
                    $"Age: {result1[index].Age} EyeColor: {result1[index].EyeColor}");
                Console.WriteLine($"Name: {result2[index].FirstName} Surname: {result2[index].LastName} " +
                    $"Age: {result2[index].Age} EyeColor: {result2[index].EyeColor}");
                Console.WriteLine();
            }

            /*  Console.WriteLine(result1.Count);
              Console.WriteLine(result2.Count);*/

            /* Console.WriteLine(result1.FirstName + " " + result1.LastName);
             Console.WriteLine(result2.FirstName + " " + result2.LastName);*/

            /*for (int index = 0; index < result1.Count; index++)
            {
                Console.WriteLine(result1[index]);
                Console.WriteLine(result2[index]);
            }*/
        }
    }
}