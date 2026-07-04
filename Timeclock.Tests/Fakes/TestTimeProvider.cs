using TimeclockControls.Abstractions;

namespace Dangerwolf.Timeclock.Tests.Fakes;

/// <summary>
/// Simple fake time provider for deterministic time-based tests.
/// The current time is controlled manually via <see cref="SetNow"/> and <see cref="AdvanceBy"/>.
/// </summary>
public sealed class TestTimeProvider : ITimeProvider
{
    private DateTime _now;

    public TestTimeProvider(DateTime? initialTime = null)
    {
        _now = initialTime ?? new DateTime(2024, 1, 1, 9, 0, 0);
    }

    public DateTime Now => _now;

    /// <summary>Sets the current time to a specific value.</summary>
    public void SetNow(DateTime time) => _now = time;

    /// <summary>Advances the current time by the specified duration.</summary>
    public void AdvanceBy(TimeSpan duration) => _now += duration;
}
