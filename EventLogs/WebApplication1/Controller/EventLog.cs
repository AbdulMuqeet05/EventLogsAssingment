using Application.ApplicationDto;
using Application.Domain;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controller;

[ApiController]
[Route("/v1/api/[controller]")]
public class EventLog : ControllerBase
{
    private readonly IEventStore _eventStore;

    public EventLog(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }
    // GET
    [HttpGet]
    public async Task<ActionResult<EventLogResponse>> GetEvents()
    {
        try
        {
            var fiveMinAgo = DateTime.Now.AddMinutes(-5);
            var result = await _eventStore.GetEvents(fiveMinAgo);
            return Ok(new EventLogResponse(result));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new EventLogResponse(null , ex.Message));
        }
       
    }
}