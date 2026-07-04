using System;
using Dangerwolf.Timeclock.Core;

namespace Dangerwolf.Timeclock.Tests.Core;

public class TaskTimeTrackerTests
{
    // ── Initial state ─────────────────────────────────────────────────────────

    [Fact]
    public void InitialState_PreviousTotalIsZero()
    {
        var tracker = new TaskTimeTracker();

        Assert.Equal(TimeSpan.Zero, tracker.PreviousTotal);
    }

    // ── OnTimerStarted ────────────────────────────────────────────────────────

    [Fact]
    public void OnTimerStarted_StoresPreviousTotal()
    {
        var tracker = new TaskTimeTracker();
        var existing = TimeSpan.FromHours(2);

        tracker.OnTimerStarted(existing);

        Assert.Equal(existing, tracker.PreviousTotal);
    }

    [Fact]
    public void OnTimerStarted_ZeroExisting_PreviousTotalRemainsZero()
    {
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.Zero);

        Assert.Equal(TimeSpan.Zero, tracker.PreviousTotal);
    }

    // ── OnTimerStopped ────────────────────────────────────────────────────────

    [Fact]
    public void OnTimerStopped_AddsPreviousTotalToElapsed()
    {
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.FromHours(1));

        var result = tracker.OnTimerStopped(TimeSpan.FromMinutes(30));

        Assert.Equal(TimeSpan.FromHours(1.5), result);
    }

    [Fact]
    public void OnTimerStopped_NoPreviousTotal_ReturnsElapsedOnly()
    {
        var tracker = new TaskTimeTracker();
        var elapsed = TimeSpan.FromMinutes(45);

        var result = tracker.OnTimerStopped(elapsed);

        Assert.Equal(elapsed, result);
    }

    [Fact]
    public void OnTimerStopped_ZeroElapsed_ReturnsPreviousTotalUnchanged()
    {
        var tracker = new TaskTimeTracker();
        var previous = TimeSpan.FromHours(3);
        tracker.OnTimerStarted(previous);

        var result = tracker.OnTimerStopped(TimeSpan.Zero);

        Assert.Equal(previous, result);
    }

    // ── GetLiveTotal ──────────────────────────────────────────────────────────

    [Fact]
    public void GetLiveTotal_ReturnsSumOfPreviousAndElapsed()
    {
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.FromHours(2));

        var live = tracker.GetLiveTotal(TimeSpan.FromMinutes(15));

        Assert.Equal(TimeSpan.FromMinutes(135), live);
    }

    [Fact]
    public void GetLiveTotal_DoesNotModifyPreviousTotal()
    {
        var tracker = new TaskTimeTracker();
        var previous = TimeSpan.FromHours(1);
        tracker.OnTimerStarted(previous);

        tracker.GetLiveTotal(TimeSpan.FromMinutes(30));

        Assert.Equal(previous, tracker.PreviousTotal);
    }

    // ── Reset ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Reset_ClearsPreviousTotal()
    {
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.FromHours(5));

        tracker.Reset();

        Assert.Equal(TimeSpan.Zero, tracker.PreviousTotal);
    }

    [Fact]
    public void Reset_AfterReset_OnTimerStoppedReturnsElapsedOnly()
    {
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.FromHours(5));
        tracker.Reset();

        var result = tracker.OnTimerStopped(TimeSpan.FromMinutes(20));

        Assert.Equal(TimeSpan.FromMinutes(20), result);
    }

    // ── Multi-session accumulation ────────────────────────────────────────────

    [Fact]
    public void MultiSession_AccumulatesCorrectly()
    {
        // Session 1: task had 1h, ran for 30m → total = 1h30m
        var tracker = new TaskTimeTracker();
        tracker.OnTimerStarted(TimeSpan.FromHours(1));
        var afterSession1 = tracker.OnTimerStopped(TimeSpan.FromMinutes(30));
        Assert.Equal(TimeSpan.FromMinutes(90), afterSession1);

        // Session 2: start again with the new total (1h30m), run for 15m → 1h45m
        tracker.OnTimerStarted(afterSession1);
        var afterSession2 = tracker.OnTimerStopped(TimeSpan.FromMinutes(15));
        Assert.Equal(TimeSpan.FromMinutes(105), afterSession2);
    }
}
