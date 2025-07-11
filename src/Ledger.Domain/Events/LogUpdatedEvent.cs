// src/LifeLedger.Domain/Events/LogUpdatedEvent.cs
using LifeLedger.Domain.Enums;
using LifeLedger.Domain.Relations;

namespace LifeLedger.Domain.Events;

public record LogUpdatedEvent(LogId logId, LogBookId logBookId, LogType logType, string title) : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
