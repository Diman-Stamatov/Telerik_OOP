using System.Globalization;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal MaxPrice = 1000000.0m;
            
            Console.WriteLine(MaxPrice.ToString("G29", CultureInfo.InvariantCulture));
            Console.WriteLine($"{MaxPrice:F0}");
        }
    }
}