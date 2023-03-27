using Cosmetics.Models.Enums;

namespace Cosmetics.Models.Contracts
{
    public interface IShampoo
    {
        int Milliliters { get; }

        UsageType Usage { get; }
    }
}