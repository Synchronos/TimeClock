using System;

namespace TimeclockControls.Abstractions;

/// <summary>
/// Abstraction over System.Diagnostics.Stopwatch to enable deterministic timer testing.
/// </summary>
public interface IStopwatchAdapter
{
    /// <summary>Gets the total elapsed time measured by the current instance.</summary>
    TimeSpan Elapsed { get; }

    /// <summary>Gets a value indicating whether the stopwatch timer is running.</summary>
    bool IsRunning { get; }

    /// <summary>Starts or resumes measuring elapsed time.</summary>
    void Start();

    /// <summary>Stops measuring elapsed time.</summary>
    void Stop();

    /// <summary>Stops time interval measurement and resets the elapsed time to zero.</summary>
    void Reset();
}
