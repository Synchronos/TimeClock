using System;
using TimeclockControls.Core;

namespace Dangerwolf.Timeclock.Tests.Core;

public class TimerStateMachineTests
{
    // ── Initial state ────────────────────────────────────────────────────────

    [Fact]
    public void InitialState_AllFlagsAreFalse()
    {
        var sm = new TimerStateMachine();

        Assert.False(sm.IsRunning);
        Assert.False(sm.IsPaused);
        Assert.False(sm.IsSplit);
    }

    [Fact]
    public void InitialState_OnlyCanStartIsTrue()
    {
        var sm = new TimerStateMachine();

        Assert.True(sm.CanStart);
        Assert.False(sm.CanPause);
        Assert.False(sm.CanResume);
        Assert.False(sm.CanStop);
        Assert.False(sm.CanSplit);
        Assert.False(sm.CanUnsplit);
        Assert.True(sm.CanClear);
    }

    // ── Start ────────────────────────────────────────────────────────────────

    [Fact]
    public void Start_FromIdle_SetsIsRunning()
    {
        var sm = new TimerStateMachine();
        sm.Start();

        Assert.True(sm.IsRunning);
        Assert.False(sm.IsPaused);
    }

    [Fact]
    public void Start_WhenAlreadyRunning_Throws()
    {
        var sm = new TimerStateMachine();
        sm.Start();

        Assert.Throws<InvalidOperationException>(() => sm.Start());
    }

    // ── Pause ────────────────────────────────────────────────────────────────

    [Fact]
    public void Pause_WhenRunning_SetsIsPaused()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();

        Assert.True(sm.IsRunning);
        Assert.True(sm.IsPaused);
    }

    [Fact]
    public void Pause_WhenNotRunning_Throws()
    {
        var sm = new TimerStateMachine();

        Assert.Throws<InvalidOperationException>(() => sm.Pause());
    }

    [Fact]
    public void Pause_WhenAlreadyPaused_Throws()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();

        Assert.Throws<InvalidOperationException>(() => sm.Pause());
    }

    // ── Resume ───────────────────────────────────────────────────────────────

    [Fact]
    public void Resume_WhenPaused_ClearsIsPaused()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();
        sm.Resume();

        Assert.True(sm.IsRunning);
        Assert.False(sm.IsPaused);
    }

    [Fact]
    public void Resume_WhenNotPaused_Throws()
    {
        var sm = new TimerStateMachine();
        sm.Start();

        Assert.Throws<InvalidOperationException>(() => sm.Resume());
    }

    // ── Stop ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Stop_WhenRunning_ClearsIsRunning()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Stop();

        Assert.False(sm.IsRunning);
        Assert.False(sm.IsPaused);
    }

    [Fact]
    public void Stop_WhenPaused_ClearsBothFlags()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();
        sm.Stop();

        Assert.False(sm.IsRunning);
        Assert.False(sm.IsPaused);
    }

    [Fact]
    public void Stop_WhenNotRunning_Throws()
    {
        var sm = new TimerStateMachine();

        Assert.Throws<InvalidOperationException>(() => sm.Stop());
    }

    // ── Split / Unsplit ───────────────────────────────────────────────────────

    [Fact]
    public void Split_WhenRunning_SetsIsSplit()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Split();

        Assert.True(sm.IsSplit);
        Assert.True(sm.IsRunning);
    }

    [Fact]
    public void Split_WhenNotRunning_Throws()
    {
        var sm = new TimerStateMachine();

        Assert.Throws<InvalidOperationException>(() => sm.Split());
    }

    [Fact]
    public void Split_WhenPaused_Throws()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();

        Assert.Throws<InvalidOperationException>(() => sm.Split());
    }

    [Fact]
    public void Unsplit_WhenSplit_ClearsIsSplit()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Split();
        sm.Unsplit();

        Assert.False(sm.IsSplit);
    }

    [Fact]
    public void Unsplit_WhenNotSplit_Throws()
    {
        var sm = new TimerStateMachine();

        Assert.Throws<InvalidOperationException>(() => sm.Unsplit());
    }

    // ── Clear ─────────────────────────────────────────────────────────────────

    [Fact]
    public void Clear_WhenStopped_ClearsSplitFlag()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Split();
        sm.Stop();
        sm.Clear();

        Assert.False(sm.IsSplit);
        Assert.False(sm.IsRunning);
    }

    [Fact]
    public void Clear_WhenRunning_Throws()
    {
        var sm = new TimerStateMachine();
        sm.Start();

        Assert.Throws<InvalidOperationException>(() => sm.Clear());
    }

    // ── Full lifecycle ────────────────────────────────────────────────────────

    [Fact]
    public void FullCycle_StartPauseResumeStop_EndsIdle()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Pause();
        sm.Resume();
        sm.Stop();

        Assert.False(sm.IsRunning);
        Assert.False(sm.IsPaused);
        Assert.False(sm.IsSplit);
        Assert.True(sm.CanStart);
    }

    [Fact]
    public void FullCycle_StartSplitUnsplitStop_EndsIdle()
    {
        var sm = new TimerStateMachine();
        sm.Start();
        sm.Split();
        sm.Unsplit();
        sm.Stop();

        Assert.False(sm.IsRunning);
        Assert.False(sm.IsSplit);
        Assert.True(sm.CanStart);
    }
}
