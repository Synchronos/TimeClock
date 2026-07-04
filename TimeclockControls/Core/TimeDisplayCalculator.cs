using System;

namespace TimeclockControls.Core;

/// <summary>
/// Pure, stateless helper that decomposes a <see cref="TimeSpan"/> into the individual
/// digit values needed by the elapsed-time display.
/// </summary>
public static class TimeDisplayCalculator
{
    /// <summary>
    /// Decomposes <paramref name="elapsed"/> into the display digit values.
    /// Hours may exceed 99 (hundreds digit is provided separately).
    /// Uses <c>TotalHours</c> so sessions longer than 24 hours display correctly.
    /// </summary>
    /// <returns>
    /// A <see cref="DisplayDigits"/> value containing all digit components.
    /// </returns>
    public static DisplayDigits GetDigits(TimeSpan elapsed)
    {
        int secondsOnes;
        int secondsTens = Math.DivRem(elapsed.Seconds, 10, out secondsOnes);

        int minutesOnes;
        int minutesTens = Math.DivRem(elapsed.Minutes, 10, out minutesOnes);

        int hoursTens;
        int hoursOnes;
        int hoursHundreds = Math.DivRem((int)elapsed.TotalHours, 100, out hoursTens);
        hoursTens = Math.DivRem(hoursTens, 10, out hoursOnes);

        return new DisplayDigits(
            hoursHundreds, hoursTens, hoursOnes,
            minutesTens, minutesOnes,
            secondsTens, secondsOnes);
    }
}

/// <summary>
/// Holds all digit positions required to render the elapsed-time display.
/// </summary>
/// <param name="HoursHundreds">Hundreds digit of total elapsed hours (0–9).</param>
/// <param name="HoursTens">Tens digit of total elapsed hours (0–9).</param>
/// <param name="HoursOnes">Ones digit of total elapsed hours (0–9).</param>
/// <param name="MinutesTens">Tens digit of the minutes component (0–5).</param>
/// <param name="MinutesOnes">Ones digit of the minutes component (0–9).</param>
/// <param name="SecondsTens">Tens digit of the seconds component (0–5).</param>
/// <param name="SecondsOnes">Ones digit of the seconds component (0–9).</param>
public readonly record struct DisplayDigits(
    int HoursHundreds,
    int HoursTens,
    int HoursOnes,
    int MinutesTens,
    int MinutesOnes,
    int SecondsTens,
    int SecondsOnes);
