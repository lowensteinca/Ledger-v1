// src/Ledger.Domain/Events/IDomainEvent.cs
using MediatR;

namespace Ledger.Domain.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
}
