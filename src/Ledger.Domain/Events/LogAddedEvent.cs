// src/Ledger.Domain/Events/LogCreatedEvent.cs
using Ledger.Domain.Enums;
using Ledger.Domain.Relations;

namespace Ledger.Domain.Events;

public record LgoAddedEvent(LogId logId, LogBookId logBookId, LogType logType, string title) : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
