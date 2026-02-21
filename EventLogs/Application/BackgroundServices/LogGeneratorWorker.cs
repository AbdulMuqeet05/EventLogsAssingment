using System.ComponentModel.Design;
using Application.Domain;
using Application.Interfaces;
using Microsoft.Extensions.Options;

namespace Application.BackgroundServices;
using Microsoft.Extensions.Hosting;
public class LogGeneratorWorker : BackgroundService
{
    private readonly IEventStore _eventStore;
    private readonly BackgroundWorkerSettings _workerSettings;
    public LogGeneratorWorker(IEventStore store, IOptions<BackgroundWorkerSettings> eventLogSettings)
    {
        _eventStore = store;
        _workerSettings = eventLogSettings.Value;
    }
    protected override async Task ExecuteAsync(CancellationToken cancellation)
    {
        PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromMilliseconds(_workerSettings.Delay));
        try
        {
            while (await timer.WaitForNextTickAsync(cancellation))
            {
                var newLog = EventGenerateRandomLogs();
                _eventStore.AddEvents(newLog);
            }
        }
        catch (Exception ex)
        {
            // _logger.Log(logLevel: LogLevel.Debug , $"Error occured while generating logs: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }

    private EventLogs EventGenerateRandomLogs()
    {
        Random random = new Random();
        DateTime timeStamp = DateTime.Now;
        var serverity = random.Next(0, 3);
        var message = $" Random Message generate at {timeStamp} and with Severity {serverity}";
        return new EventLogs()
        {
            TimeStamp = timeStamp,
            Severity = (Severity) serverity,
            Message = message
        };
    }
}