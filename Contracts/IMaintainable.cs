
public interface IMaintainable
{
    DateTime? LastServiceDate { get; }
    void ScheduleService(DateTime date);
    bool IsServiceDue();
}