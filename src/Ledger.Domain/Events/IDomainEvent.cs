// src/LifeLedger.Domain/Events/IDomainEvent.cs
using MediatR;

namespace LifeLedger.Domain.Events;

public interface IDomainEvent : INotification
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
}
