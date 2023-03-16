using Cosmetics.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics.Helpers
{
    public class ValidationHelpers
    {
        public static void ValidateIntRange(int minLength, int maxLength, int actualLength, string errorMessage)
        {
            if (actualLength < minLength || actualLength > maxLength)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void ValidateStringLength(string stringToValidate, int minLength, int maxLength, string errorMessage)
        {
            ValidateIntRange(minLength, maxLength, stringToValidate.Length, errorMessage);
        }

        public static void ValidateArgumentsCount(IList<string> list, int expectedNumberOfParameters)
        {
            if (list.Count < expectedNumberOfParameters || list.Count > expectedNumberOfParameters)
            {
                throw new ArgumentException(string.Format($"Invalid number of arguments. Expected: {expectedNumberOfParameters}; received: {list.Count}."));
            }
        }
        public static int FindProductIndex (List<Product> products, Product productToRemove)
        {
            int index = products.FindIndex(product=>product.Name == productToRemove.Name
            && product.Brand == productToRemove.Brand
            && product.Gender == productToRemove.Gender);
            if (index < 0)
            {
                throw new ArgumentException("The specified product does not exist!");
            }
            return index;
        }
    }
}
