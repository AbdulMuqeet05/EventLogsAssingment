using Xunit;
using Application.BackgroundServices;
using Application.Domain;
using Application.Interfaces;
using Microsoft.Extensions.Options;
using NSubstitute;

namespace Application.UnitTests;

public class LogGeneratorWorkerTest
{
    [Fact]
    public async Task Worker_Should_Add_Event_To_Store()
    {
        var settings = new BackgroundWorkerSettings() { Delay = 10 };
        var options = Options.Create(settings);
        var mockStore = Substitute.For<IEventStore>();


        var worker = new LogGeneratorWorker(mockStore, options);
        var cancellationToken = new CancellationTokenSource();

        var task = worker.StartAsync(cancellationToken.Token);
        await Task.Delay(50);
        cancellationToken.Cancel();
        
        mockStore.Received().AddEvents(Arg.Any<EventLogs>());
    }
    
}