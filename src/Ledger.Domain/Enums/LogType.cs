// src/Ledger.Domain/Enums/LogType.cs
namespace Ledger.Domain.Enums;

public enum LogType
{
    /// <summary>
    /// Represents a log entry that is a memory
    /// </summary>
    Memory = 1,

    /// <summary>
    /// Represents a log entry that is a mistake.
    /// </summary>
    Mistake = 2,

    /// <summary>
    /// Represents a log entry that is an achievement.
    /// </summary>
    Achievement = 3,
    /// <summary>
    /// Represents a log entry that is a note (generic).
    /// </summary>
    Note = 4
}
