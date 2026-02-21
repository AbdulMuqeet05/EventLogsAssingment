using Application.Domain;

namespace Application.ApplicationDto;

public record EventLogResponse(
    EventLogs [] Data,
    string? ErrorMessage = null
    );