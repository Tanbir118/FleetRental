public interface IReportable
{
    string Id { get; }

    string ToReportLine()
    {
        return $"[{Id}] {GetType().Name}";
    }
}