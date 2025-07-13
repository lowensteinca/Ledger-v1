// src/Ledger.Domain/Entities/User.cs
using System.Diagnostics.Contracts;
using Ledger.Domain.Events;
using Ledger.Domain.Relations;

namespace Ledger.Domain.Entities;

public class User : BaseEntity<UserId>
{
    // private readonly List<LogBook> logBooks = new();

    public string Username { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // public IReadOnlyCollection<LogBook> LogBooks => logBooks.AsReadOnly();

    private User() { }

    // public static User Create(string userrname, string email, string firstName, string lastName)

    // public void UpdateProfile(string firstName, string lastName) { }

    // public LogBook CreateLogBook(string title, string? description = null)
    // {
    //     var logBook = LogBook.Create(Id, title, description);
    //     _logBooks.Add(logBook);
    //     return logBook;
    // }
}
