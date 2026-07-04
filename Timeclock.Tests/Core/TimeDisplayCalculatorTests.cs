using System;
using TimeclockControls.Core;

namespace Dangerwolf.Timeclock.Tests.Core;

public class TimeDisplayCalculatorTests
{
    // ── Seconds ──────────────────────────────────────────────────────────────

    [Fact]
    public void GetDigits_ZeroElapsed_AllDigitsZero()
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.Zero);

        Assert.Equal(0, d.SecondsOnes);
        Assert.Equal(0, d.SecondsTens);
        Assert.Equal(0, d.MinutesOnes);
        Assert.Equal(0, d.MinutesTens);
        Assert.Equal(0, d.HoursOnes);
        Assert.Equal(0, d.HoursTens);
        Assert.Equal(0, d.HoursHundreds);
    }

    [Theory]
    [InlineData(9,  0, 9)]
    [InlineData(10, 1, 0)]
    [InlineData(59, 5, 9)]
    public void GetDigits_SecondsOnly_CorrectSecondDigits(int seconds, int expectedTens, int expectedOnes)
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromSeconds(seconds));

        Assert.Equal(expectedTens, d.SecondsTens);
        Assert.Equal(expectedOnes, d.SecondsOnes);
    }

    // ── Minutes ──────────────────────────────────────────────────────────────

    [Theory]
    [InlineData(1,  0, 1)]
    [InlineData(10, 1, 0)]
    [InlineData(59, 5, 9)]
    public void GetDigits_MinutesOnly_CorrectMinuteDigits(int minutes, int expectedTens, int expectedOnes)
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromMinutes(minutes));

        Assert.Equal(expectedTens, d.MinutesTens);
        Assert.Equal(expectedOnes, d.MinutesOnes);
    }

    // ── Hours (no wraparound) ─────────────────────────────────────────────────

    [Theory]
    [InlineData(1,   0, 0, 1)]
    [InlineData(9,   0, 0, 9)]
    [InlineData(10,  0, 1, 0)]
    [InlineData(23,  0, 2, 3)]
    [InlineData(99,  0, 9, 9)]
    public void GetDigits_HoursUnder100_CorrectHourDigits(int hours, int expectedHundreds, int expectedTens, int expectedOnes)
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromHours(hours));

        Assert.Equal(expectedHundreds, d.HoursHundreds);
        Assert.Equal(expectedTens,     d.HoursTens);
        Assert.Equal(expectedOnes,     d.HoursOnes);
    }

    // ── Key bug regression: hours must NOT wrap at 24 ──────────────────────

    [Fact]
    public void GetDigits_Exactly24Hours_Shows24NotZero()
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromHours(24));

        Assert.Equal(2, d.HoursTens);
        Assert.Equal(4, d.HoursOnes);
        Assert.Equal(0, d.HoursHundreds);
    }

    [Fact]
    public void GetDigits_25Hours30Minutes_CorrectAllDigits()
    {
        var elapsed = new TimeSpan(25, 30, 45);
        var d = TimeDisplayCalculator.GetDigits(elapsed);

        Assert.Equal(0, d.HoursHundreds);
        Assert.Equal(2, d.HoursTens);
        Assert.Equal(5, d.HoursOnes);
        Assert.Equal(3, d.MinutesTens);
        Assert.Equal(0, d.MinutesOnes);
        Assert.Equal(4, d.SecondsTens);
        Assert.Equal(5, d.SecondsOnes);
    }

    [Fact]
    public void GetDigits_100Hours_CorrectHundredsDigit()
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromHours(100));

        Assert.Equal(1, d.HoursHundreds);
        Assert.Equal(0, d.HoursTens);
        Assert.Equal(0, d.HoursOnes);
    }

    [Fact]
    public void GetDigits_123Hours_CorrectAllHourDigits()
    {
        var d = TimeDisplayCalculator.GetDigits(TimeSpan.FromHours(123));

        Assert.Equal(1, d.HoursHundreds);
        Assert.Equal(2, d.HoursTens);
        Assert.Equal(3, d.HoursOnes);
    }
}
