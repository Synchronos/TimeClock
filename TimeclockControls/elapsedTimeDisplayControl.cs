using System;
using System.Windows.Forms;
using TimeclockControls.Core;

namespace TimeclockControls
{
    public partial class elapsedTimeDisplayControl : UserControl
    {
        public elapsedTimeDisplayControl()
        {
            InitializeComponent();
            blankElapsedTime();
        }

        #region "Elapsed Time Display Updaters"

        /// <summary>
        /// Blanks the elapsed time.
        /// </summary>
        public void blankElapsedTime()
        {
            picElapsedHoursHundreds.Image = displayGraphics.blankDigitBitmap;
            picElapsedHoursTens.Image = displayGraphics.blankDigitBitmap;
            picElapsedHoursOnes.Image = displayGraphics.blankDigitBitmap;
            picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
            picElapsedMinutesTens.Image = displayGraphics.blankDigitBitmap;
            picElapsedMinutesOnes.Image = displayGraphics.blankDigitBitmap;
            picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
            picElapsedSecondsTens.Image = displayGraphics.blankDigitBitmap;
            picElapsedSecondsOnes.Image = displayGraphics.blankDigitBitmap;
        }

        /// <summary>
        /// Updates the elapsed time.
        /// </summary>
        public void updateElapsedTime(TimeSpan elapsedTime)
        {
            var d = TimeDisplayCalculator.GetDigits(elapsedTime);

            // Update only the necessary digits in the elapsed time display.
            picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[d.SecondsOnes];
            if (d.SecondsOnes == 0)
            {
                picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[d.SecondsTens];
                if (elapsedTime.Seconds == 0)
                {
                    picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[d.MinutesOnes];
                    if (d.MinutesOnes == 0)
                    {
                        picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[d.MinutesTens];
                        if (elapsedTime.Minutes == 0)
                        {
                            picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[d.HoursOnes];
                            if (d.HoursOnes == 0)
                            {
                                picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[d.HoursTens];
                                if (d.HoursTens == 0)
                                {
                                    picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[d.HoursHundreds];
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Updates the elapsed time (all digits).
        /// </summary>
        public void updateElapsedTimeAllDigits(TimeSpan elapsedTime)
        {
            var d = TimeDisplayCalculator.GetDigits(elapsedTime);

            picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[d.SecondsOnes];
            picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[d.SecondsTens];
            picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[d.MinutesOnes];
            picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[d.MinutesTens];
            picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[d.HoursOnes];
            picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[d.HoursTens];
            picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[d.HoursHundreds];

            picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
            picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
        }

        /// <summary>
        /// Updates the elapsed time digit seperators.
        /// </summary>
        public void updateElapsedTimeDigitSeperators(DateTime currentDateTime, bool isPaused, bool isSplit)
        {
            // Blink the digit seperators with symbols appropriate to the current mode.
            if (isSplit && isPaused)
            {
                if (currentDateTime.Second % 2 == 0)
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
                }
                else
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.dashBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.dashBitmap;
                }
            }
            else if (isSplit)
            {
                if (currentDateTime.Second % 2 == 0)
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.blankDigitBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.blankDigitBitmap;
                }
                else
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.dashBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.dashBitmap;
                }
            }
            else if (isPaused)
            {
                if (currentDateTime.Second % 2 == 0)
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.blankDigitBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.blankDigitBitmap;
                }
                else
                {
                    picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
                    picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
                }
            }
        }

        #endregion
    }
}
