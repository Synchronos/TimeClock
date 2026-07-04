using System;

namespace TimeclockControls.Abstractions;

/// <summary>
/// Production implementation of <see cref="ITimeProvider"/> using the system clock.
/// </summary>
public sealed class SystemTimeProvider : ITimeProvider
{
    public DateTime Now => DateTime.Now;
}
