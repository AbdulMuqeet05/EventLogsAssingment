using System.Collections.Concurrent;
using Application.Domain;
using Application.Interfaces;
using Microsoft.Extensions.Options;

namespace EventStore.Store;

public class EventStore : IEventStore
{
    private readonly ConcurrentQueue<EventLogs> _queue;
    private readonly EventLogSettings _settings;

    public EventStore(IOptions<EventLogSettings> settings)
    {
        _queue= new ConcurrentQueue<EventLogs>();
        _settings = settings.Value;
    }
    public void AddEvents(EventLogs events)
    {
        _queue.Enqueue(events);

        while (_queue.Count > _settings.MaxLimit)
        {
            _queue.TryDequeue(out _);
        }
    }
    
    public Task<EventLogs[]> GetEvents(DateTime timeStamp, CancellationToken cancellationToken = default)
    {
        var result = _queue.Where(c => c.TimeStamp >= timeStamp).ToArray();
        return Task.FromResult(result);
    }
    
}

