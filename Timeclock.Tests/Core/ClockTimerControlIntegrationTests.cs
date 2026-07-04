using System;
using Dangerwolf.Timeclock.Tests.Fakes;
using Dangerwolf.Timeclock.Tests.Infrastructure;
using TimeclockControls;

namespace Dangerwolf.Timeclock.Tests.Core;

/// <summary>
/// Integration tests for clockTimerControl using FakeStopwatch and TestTimeProvider.
/// All tests run on an STA thread because clockTimerControl is a WinForms UserControl.
/// </summary>
public class ClockTimerControlIntegrationTests
{
    // ── Start ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Start_SetsIsRunning()
    {
        StaRunner.Run(() =>
        {
            var (control, _, _) = CreateControl();

            control.TestStart();

            Assert.True(control.IsRunning);
            Assert.False(control.IsPaused);
        });
    }

    [Fact]
    public void Start_CapturesStartTimeFromTimeProvider()
    {
        StaRunner.Run(() =>
        {
            var startTime = new DateTime(2024, 6, 1, 9, 0, 0);
            var (control, _, timeProvider) = CreateControl();
            timeProvider.SetNow(startTime);

            control.TestStart();

            Assert.Equal(startTime, control.GetStartDate());
        });
    }

    [Fact]
    public void Start_ResetsElapsedTime()
    {
        StaRunner.Run(() =>
        {
            var (control, stopwatch, _) = CreateControl();
            stopwatch.SetElapsed(TimeSpan.FromHours(1));

            control.TestStart();

            Assert.Equal(TimeSpan.Zero, control.GetElapsedTime());
        });
    }

    // ── Pause / Resume ────────────────────────────────────────────────────────

    [Fact]
    public void Pause_SetsIsPaused()
    {
        StaRunner.Run(() =>
        {
            var (control, _, _) = CreateControl();
            control.TestStart();

            control.TestPause();

            Assert.True(control.IsPaused);
            Assert.True(control.IsRunning);
        });
    }

    [Fact]
    public void Resume_ClearsIsPaused()
    {
        StaRunner.Run(() =>
        {
            var (control, _, _) = CreateControl();
            control.TestStart();
            control.TestPause();

            control.TestResume();

            Assert.False(control.IsPaused);
            Assert.True(control.IsRunning);
        });
    }

    // ── Stop ──────────────────────────────────────────────────────────────────

    [Fact]
    public void Stop_ClearsIsRunning()
    {
        StaRunner.Run(() =>
        {
            var (control, _, _) = CreateControl();
            control.TestStart();

            control.TestStop();

            Assert.False(control.IsRunning);
        });
    }

    [Fact]
    public void Stop_PreservesElapsedTimeFromStopwatch()
    {
        StaRunner.Run(() =>
        {
            var (control, stopwatch, _) = CreateControl();
            control.TestStart();
            stopwatch.AdvanceBy(TimeSpan.FromHours(2));

            control.TestStop();

            Assert.Equal(TimeSpan.FromHours(2), control.GetElapsedTime());
        });
    }

    // ── Start time preserved on resume ────────────────────────────────────────

    [Fact]
    public void Resume_DoesNotChangeStartDate()
    {
        StaRunner.Run(() =>
        {
            var startTime = new DateTime(2024, 6, 1, 8, 0, 0);
            var (control, _, timeProvider) = CreateControl();
            timeProvider.SetNow(startTime);
            control.TestStart();

            timeProvider.AdvanceBy(TimeSpan.FromHours(1));
            control.TestPause();
            control.TestResume();

            Assert.Equal(startTime, control.GetStartDate());
        });
    }

    // ── Split ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Split_SetsIsSplit()
    {
        StaRunner.Run(() =>
        {
            var (control, _, _) = CreateControl();
            control.TestStart();

            control.TestSplit();

            Assert.True(control.IsSplit);
        });
    }

    // ── Helper ────────────────────────────────────────────────────────────────

    private static (clockTimerControl control, FakeStopwatch stopwatch, TestTimeProvider timeProvider)
        CreateControl()
    {
        var stopwatch    = new FakeStopwatch();
        var timeProvider = new TestTimeProvider();
        var control      = new clockTimerControl(stopwatch, timeProvider);
        return (control, stopwatch, timeProvider);
    }
}
