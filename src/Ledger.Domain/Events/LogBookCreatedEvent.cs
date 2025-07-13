// src/Ledger.Domain/Events/LogBookCreated.cs
using Ledger.Domain.Enums;
using Ledger.Domain.Relations;

namespace Ledger.Domain.Events;

public record LogBookCreatedEvent(LogBookId logBookId, UserId userId, string title) : IDomainEvent
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
