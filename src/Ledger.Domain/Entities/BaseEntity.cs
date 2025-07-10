// src/LifeLedger.Domain/Entities/BaseEntity.cs
using LifeLedger.Domain.Events;

namespace LifeLedger.Domain.Entities;

public abstract class BaseEntity<TId> : IEquatable<BaseEntity<TId>>
{
    public TId Id { get; protected set; } = default!;
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public bool Equals(BaseEntity<TId>? other)
    {
        return other is not null && Id!.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is BaseEntity<TId> entity && Equals(entity);
    }

    public override int GetHashCode()
    {
        return Id?.GetHashCode() ?? 0;
    }

    public static bool operator ==(BaseEntity<TId>? left, BaseEntity<TId>? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseEntity<TId>? left, BaseEntity<TId>? right)
    {
        return !Equals(left, right);
    }
}
