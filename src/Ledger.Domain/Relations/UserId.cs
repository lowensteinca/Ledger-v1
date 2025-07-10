// src/LifeLedger.Domain/Relations/UserId.cs
namespace LifeLedger.Domain.Relations;

public record UserId(Guid Value)
{
    public static UserId New() => new(Guid.NewGuid());
    public static UserId Empty => new(Guid.Empty);
    public static implicit operator Guid(UserId id) => id.Value;
    public static explicit operator UserId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
