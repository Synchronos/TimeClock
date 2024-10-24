using System;
using System.Windows.Forms;

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
            this.picElapsedHoursHundreds.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedHoursTens.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedHoursOnes.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
            this.picElapsedMinutesTens.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedMinutesOnes.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
            this.picElapsedSecondsTens.Image = displayGraphics.blankDigitBitmap;
            this.picElapsedSecondsOnes.Image = displayGraphics.blankDigitBitmap;
        }

        /// <summary>
        /// Updates the elapsed time.
        /// </summary>
        public void updateElapsedTime(TimeSpan elapsedTime)
        {
            // Update the elapsed time display if appropriate.
            int secondsOnes = 0;
            int secondsTens = Math.DivRem(elapsedTime.Seconds, 10, out secondsOnes);

            // Update only the necessary digits in the elapsed time display.
            this.picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[secondsOnes];
            if (secondsOnes == 0)
            {
                this.picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[secondsTens];
                if (elapsedTime.Seconds == 0)
                {
                    int minutesOnes = 0;
                    int minutesTens = Math.DivRem(elapsedTime.Minutes, 10, out minutesOnes);

                    this.picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[minutesOnes];
                    if (minutesOnes == 0)
                    {
                        this.picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[minutesTens];
                        if (elapsedTime.Minutes == 0)
                        {
                            int hoursOnes = 0;
                            int hoursTens = 0;
                            int hoursHundreds = Math.DivRem(elapsedTime.Hours, 100, out hoursTens);
                            hoursTens = Math.DivRem(hoursTens, 10, out hoursOnes);

                            this.picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[hoursOnes];
                            if (hoursOnes == 0)
                            {
                                this.picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[hoursTens];
                                if (hoursTens == 0)
                                {
                                    this.picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[hoursHundreds];
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
            int secondsOnes = 0;
            int secondsTens = Math.DivRem(elapsedTime.Seconds, 10, out secondsOnes);

            this.picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[secondsOnes];
            this.picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[secondsTens];

            int minutesOnes = 0;
            int minutesTens = Math.DivRem(elapsedTime.Minutes, 10, out minutesOnes);

            this.picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[minutesOnes];
            this.picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[minutesTens];

            int hoursOnes = 0;
            int hoursTens = 0;
            int hoursHundreds = Math.DivRem(elapsedTime.Hours, 100, out hoursTens);
            hoursTens = Math.DivRem(hoursTens, 10, out hoursOnes);

            this.picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[hoursOnes];
            this.picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[hoursTens];
            this.picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[hoursHundreds];

            this.picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
            this.picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
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
                    this.picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
                }
                else
                {
                    this.picElapsedMinutesSeperator.Image = displayGraphics.dashBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.dashBitmap;
                }
            }
            else if (isSplit)
            {
                if (currentDateTime.Second % 2 == 0)
                {
                    this.picElapsedMinutesSeperator.Image = displayGraphics.blankDigitBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.blankDigitBitmap;
                }
                else
                {
                    this.picElapsedMinutesSeperator.Image = displayGraphics.dashBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.dashBitmap;
                }
            }
            else if (isPaused)
            {
                if (currentDateTime.Second % 2 == 0)
                {
                    this.picElapsedMinutesSeperator.Image = displayGraphics.blankDigitBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.blankDigitBitmap;
                }
                else
                {
                    this.picElapsedMinutesSeperator.Image = displayGraphics.colonBitmap;
                    this.picElapsedSecondsSeperator.Image = displayGraphics.colonBitmap;
                }
            }
        }

        #endregion
    }
}
