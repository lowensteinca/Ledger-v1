// src/Ledger.Domain/Relations/TagId.cs
namespace Ledger.Domain.Relations;

public record TagId(Guid Value)
{
    public static TagId New() => new(Guid.NewGuid());
    public static TagId Empty => new(Guid.Empty);
    public static implicit operator Guid(TagId id) => id.Value;
    public static explicit operator TagId(Guid value) => new(value);
    public override string ToString() => Value.ToString();
}
