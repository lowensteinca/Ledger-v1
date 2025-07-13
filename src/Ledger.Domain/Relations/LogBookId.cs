// src/Ledger.Domain/Relations/LogBookId.cs
namespace Ledger.Domain.Relations;

public record LogBookId(Guid Value)
{
    public static LogBookId New() => new(Guid.NewGuid());
    public static LogBookId Empty => new(Guid.Empty);
    public static implicit operator Guid(LogBookId id) => id.Value;
    public static explicit operator LogBookId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
