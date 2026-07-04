using System;

namespace Dangerwolf.Timeclock.Core;

/// <summary>
/// Tracks the accumulated time for a single task across multiple start/pause/resume/stop cycles.
/// This class is pure (no UI, no stopwatch, no DateTime.Now) and is fully unit-testable.
/// </summary>
public sealed class TaskTimeTracker
{
    private TimeSpan _previousTotal = TimeSpan.Zero;

    /// <summary>
    /// Gets the time that was already recorded for the task before the current timer session began.
    /// </summary>
    public TimeSpan PreviousTotal => _previousTotal;

    /// <summary>
    /// Called when the timer is started for a task. Captures the task's previously accumulated total.
    /// </summary>
    /// <param name="existingTotal">The <c>TotalTime</c> already stored on the task data row.</param>
    public void OnTimerStarted(TimeSpan existingTotal)
    {
        _previousTotal = existingTotal;
    }

    /// <summary>
    /// Calculates the new total time when the timer is stopped.
    /// </summary>
    /// <param name="elapsed">The elapsed time from the stopwatch at the moment the timer stops.</param>
    /// <returns>The total time to write back to the task: <see cref="PreviousTotal"/> + <paramref name="elapsed"/>.</returns>
    public TimeSpan OnTimerStopped(TimeSpan elapsed)
    {
        return _previousTotal + elapsed;
    }

    /// <summary>
    /// Calculates the running total during a live tick update (timer still running).
    /// </summary>
    /// <param name="elapsed">The current elapsed time from the stopwatch.</param>
    /// <returns>The live total time: <see cref="PreviousTotal"/> + <paramref name="elapsed"/>.</returns>
    public TimeSpan GetLiveTotal(TimeSpan elapsed)
    {
        return _previousTotal + elapsed;
    }

    /// <summary>
    /// Resets the tracker, clearing the previous total.
    /// Call this when the task association is removed or the timer is cleared.
    /// </summary>
    public void Reset()
    {
        _previousTotal = TimeSpan.Zero;
    }
}
