using System;
using System.Diagnostics;

namespace TimeclockControls.Abstractions;

/// <summary>
/// Production implementation of <see cref="IStopwatchAdapter"/> wrapping <see cref="Stopwatch"/>.
/// </summary>
public sealed class StopwatchAdapter : IStopwatchAdapter
{
    private readonly Stopwatch _stopwatch = new();

    public TimeSpan Elapsed => _stopwatch.Elapsed;
    public bool IsRunning => _stopwatch.IsRunning;

    public void Start() => _stopwatch.Start();
    public void Stop() => _stopwatch.Stop();
    public void Reset() => _stopwatch.Reset();
}
