using Application.Domain;

namespace Application.Interfaces;

public interface IEventStore
{
    void AddEvents (EventLogs events);
    Task<EventLogs[]> GetEvents (DateTime timeStamp, CancellationToken cancellationToken = default);
}