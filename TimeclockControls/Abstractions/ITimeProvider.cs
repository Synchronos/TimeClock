using System;

namespace TimeclockControls.Abstractions;

/// <summary>
/// Minimal abstraction for providing the current date and time.
/// Used only for timer start-time capture; all UI clock displays use DateTime.Now directly.
/// </summary>
public interface ITimeProvider
{
    /// <summary>Gets the current local date and time.</summary>
    DateTime Now { get; }
}
