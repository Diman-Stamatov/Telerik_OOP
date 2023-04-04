namespace Dealership.Models.Contracts
{
    public interface IComment
    {
        string Content { get; }

        string Author { get; }

        IComment Clone();
        bool Equals(object comment);
    }
}
