using System;

namespace TimeclockControls.Core;

/// <summary>
/// Tracks and enforces the valid state transitions for a clock timer
/// (Idle → Running → Paused → Running → Stopped / Split).
/// This class has no UI or stopwatch dependencies and is fully unit-testable.
/// </summary>
public sealed class TimerStateMachine
{
    // ── State ────────────────────────────────────────────────────────────────

    /// <summary>Gets a value indicating whether the timer is currently running (including when paused).</summary>
    public bool IsRunning { get; private set; }

    /// <summary>Gets a value indicating whether the timer is currently paused.</summary>
    public bool IsPaused { get; private set; }

    /// <summary>Gets a value indicating whether the display is currently split (frozen).</summary>
    public bool IsSplit { get; private set; }

    // ── Guard properties ─────────────────────────────────────────────────────

    /// <summary>Returns <c>true</c> when calling <see cref="Start"/> is valid.</summary>
    public bool CanStart => !IsRunning && !IsSplit;

    /// <summary>Returns <c>true</c> when calling <see cref="Pause"/> is valid.</summary>
    public bool CanPause => IsRunning && !IsPaused;

    /// <summary>Returns <c>true</c> when calling <see cref="Resume"/> is valid.</summary>
    public bool CanResume => IsRunning && IsPaused;

    /// <summary>Returns <c>true</c> when calling <see cref="Stop"/> is valid.</summary>
    public bool CanStop => IsRunning;

    /// <summary>Returns <c>true</c> when calling <see cref="Split"/> is valid.</summary>
    public bool CanSplit => IsRunning && !IsPaused && !IsSplit;

    /// <summary>Returns <c>true</c> when calling <see cref="Unsplit"/> is valid.</summary>
    public bool CanUnsplit => IsSplit;

    /// <summary>Returns <c>true</c> when calling <see cref="Clear"/> is valid.</summary>
    public bool CanClear => !IsRunning;

    // ── Transitions ──────────────────────────────────────────────────────────

    /// <summary>
    /// Transitions from Idle to Running.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is already running or split.</exception>
    public void Start()
    {
        if (!CanStart)
            throw new InvalidOperationException("Timer can only be started from the idle (not running, not split) state.");

        IsRunning = true;
        IsPaused = false;
    }

    /// <summary>
    /// Transitions from Running to Paused.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is not running or already paused.</exception>
    public void Pause()
    {
        if (!CanPause)
            throw new InvalidOperationException("Timer can only be paused while running and not already paused.");

        IsPaused = true;
    }

    /// <summary>
    /// Transitions from Paused back to Running.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is not paused.</exception>
    public void Resume()
    {
        if (!CanResume)
            throw new InvalidOperationException("Timer can only be resumed while running and paused.");

        IsPaused = false;
    }

    /// <summary>
    /// Stops the timer, transitioning back to the Idle state.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is not running.</exception>
    public void Stop()
    {
        if (!CanStop)
            throw new InvalidOperationException("Timer can only be stopped while running.");

        IsRunning = false;
        IsPaused = false;
    }

    /// <summary>
    /// Freezes the display (split). The underlying stopwatch continues running.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer cannot be split in the current state.</exception>
    public void Split()
    {
        if (!CanSplit)
            throw new InvalidOperationException("Timer can only be split while running and not paused.");

        IsSplit = true;
    }

    /// <summary>
    /// Resumes display updates after a split.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is not currently split.</exception>
    public void Unsplit()
    {
        if (!CanUnsplit)
            throw new InvalidOperationException("Timer can only be unsplit while split.");

        IsSplit = false;
    }

    /// <summary>
    /// Clears the timer, returning to the initial idle state.
    /// Valid only when the timer is stopped.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if the timer is still running.</exception>
    public void Clear()
    {
        if (!CanClear)
            throw new InvalidOperationException("Timer can only be cleared while stopped.");

        IsSplit = false;
    }
}
