namespace Dealership.Models.Contracts
{
    public interface IComment: IPrintable
    {
        string Content { get; }

        string Author { get; }

        IComment Clone();
        bool Equals(object comment);
    }
}
