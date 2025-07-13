// src/Ledger.Domain/Entities/LogBook.cs
using Ledger.Domain.Events;
using Ledger.Domain.Relations;

namespace Ledger.Domain.Entities;

public class LogBook : BaseEntity<LogBookId>
{
    private readonly List<Log> _logs = new();

    public UserId userId { get; private set; }
    public string username { get; private set; } = string.Empty;
    public string title { get; private set; }
    public string? content { get; private set; }
    public DateTime createdAt { get; private set; }
    public DateTime? updatedAt { get; private set; }

    public User user { get; private set; } = null!;
    public IReadOnlyCollection<Log> logs => _logs.AsReadOnly();

    private LogBook() { }

    public LogBook Create(string userName, string title, string? description = null)
    {
        var logBook = new LogBook
        {
            Id = LogBookId.New(),
            username = userName,
            userId = userId,
            title = title,
            content = description,
            createdAt = DateTime.UtcNow,
            updatedAt = DateTime.UtcNow
        };

        logBook.AddDomainEvent(new LogBookCreatedEvent(logBook.Id, userId, title));
        return logBook;
    }

    public void UpdateDetails(string newTitle, string? description)
    {
        title = newTitle;
        content = description;
        updatedAt = DateTime.UtcNow;
    }

    // public LogBook CreateLogBook(string title, string? description = null)
    // {

    // }
}
