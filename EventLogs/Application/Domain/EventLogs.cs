namespace Application.Domain;

public class EventLogs()
{

    public DateTime TimeStamp { get; set; }
    public Severity Severity { get; set; }
    public string Message { get; set; }
}