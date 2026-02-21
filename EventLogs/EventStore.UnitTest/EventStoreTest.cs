

using EventStore.Store;

namespace EventStore.UnitTest;
using Microsoft.Extensions.Options;
using Application.Domain;
using Xunit;
public class EventStoreTest
{
    
    
    [Fact]
    public void AddEvents_WhenLimitReached_ShouldDequeueOldest()
    {
        var settings = new EventLogSettings{ MaxLimit = 2 };
        var options = Options.Create(settings);
        var eventStoreTest = new Store.EventStore(options);

        var log1 = new EventLogs { TimeStamp = DateTime.UtcNow, Severity = Severity.Low, Message = "First Log"};
        var log2 = new EventLogs { TimeStamp = DateTime.UtcNow, Severity = Severity.Medium, Message = "Second Log"};
        var log3 = new EventLogs { TimeStamp = DateTime.UtcNow, Severity = Severity.High, Message = "Third Log"};
        
        eventStoreTest.AddEvents(log1);
        eventStoreTest.AddEvents(log2);
        eventStoreTest.AddEvents(log3);

        var results = eventStoreTest.GetEvents(DateTime.UtcNow.AddMinutes(-1)).Result;
        Assert.Equal(2, results.Length);
        Assert.DoesNotContain(results, l => l.Message == "First Log");
        Assert.Contains(results, l => l.Message == "Second Log");
        Assert.Contains(results, l => l.Message == "Third Log");
    }
    
}