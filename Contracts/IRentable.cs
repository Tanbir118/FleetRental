public interface IRentable
{
    bool IsAvailable { get; }
    void MarkRented();
    void MarkReturned();
}