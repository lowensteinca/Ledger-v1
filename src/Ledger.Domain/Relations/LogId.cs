// src/Ledger.Domain/Relations/LogId.cs
namespace Ledger.Domain.Relations;

public record LogId(Guid Value)
{
    public static LogId New() => new(Guid.NewGuid());
    public static LogId Empty => new(Guid.Empty);
    public static implicit operator Guid(LogId id) => id.Value;
    public static explicit operator LogId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
