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
            var d = TimeDisplayCalculator.GetDigits(elapsedTime);

            // Update only the necessary digits in the elapsed time display.
            this.picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[d.SecondsOnes];
            if (d.SecondsOnes == 0)
            {
                this.picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[d.SecondsTens];
                if (elapsedTime.Seconds == 0)
                {
                    this.picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[d.MinutesOnes];
                    if (d.MinutesOnes == 0)
                    {
                        this.picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[d.MinutesTens];
                        if (elapsedTime.Minutes == 0)
                        {
                            this.picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[d.HoursOnes];
                            if (d.HoursOnes == 0)
                            {
                                this.picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[d.HoursTens];
                                if (d.HoursTens == 0)
                                {
                                    this.picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[d.HoursHundreds];
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

            this.picElapsedSecondsOnes.Image = displayGraphics.numericDigitBitmaps[d.SecondsOnes];
            this.picElapsedSecondsTens.Image = displayGraphics.numericDigitBitmaps[d.SecondsTens];
            this.picElapsedMinutesOnes.Image = displayGraphics.numericDigitBitmaps[d.MinutesOnes];
            this.picElapsedMinutesTens.Image = displayGraphics.numericDigitBitmaps[d.MinutesTens];
            this.picElapsedHoursOnes.Image = displayGraphics.numericDigitBitmaps[d.HoursOnes];
            this.picElapsedHoursTens.Image = displayGraphics.numericDigitBitmaps[d.HoursTens];
            this.picElapsedHoursHundreds.Image = displayGraphics.numericDigitBitmaps[d.HoursHundreds];

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
