
using Dealership.Models.Contracts;

namespace Dealership.Models
{
    public class Motorcycle :Vehicle, IMotorcycle
    {

        public const int MotorcycleWheels = 2;
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        public const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";

        public string Category => throw new System.NotImplementedException();

        //ToDo
    }
}
