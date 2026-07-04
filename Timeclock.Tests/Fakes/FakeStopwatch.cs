using TimeclockControls.Abstractions;

namespace Dangerwolf.Timeclock.Tests.Fakes;

/// <summary>
/// Simple fake stopwatch for deterministic timer tests.
/// Elapsed time is controlled manually via <see cref="AdvanceBy"/> and <see cref="SetElapsed"/>.
/// </summary>
public sealed class FakeStopwatch : IStopwatchAdapter
{
    private TimeSpan _elapsed;

    public TimeSpan Elapsed => _elapsed;
    public bool IsRunning { get; private set; }

    public void Start() => IsRunning = true;
    public void Stop() => IsRunning = false;

    public void Reset()
    {
        _elapsed = TimeSpan.Zero;
        IsRunning = false;
    }

    /// <summary>Advances elapsed time by <paramref name="duration"/>. Only works while running.</summary>
    public void AdvanceBy(TimeSpan duration)
    {
        if (IsRunning)
            _elapsed += duration;
    }

    /// <summary>Sets elapsed time to a specific value regardless of running state.</summary>
    public void SetElapsed(TimeSpan elapsed) => _elapsed = elapsed;
}
