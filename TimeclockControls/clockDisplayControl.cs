using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TimeclockControls
{
    public partial class clockDisplayControl : UserControl
    {
        private bool use24HourClock = false;

        /// <summary>
        /// Gets or sets a value indicating whether [use 24 hour clock].
        /// </summary>
        /// <value><c>true</c> if [use 24 hour clock]; otherwise, <c>false</c>.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Use24HourClock
        {
            get
            {
                return use24HourClock;
            }
            set
            {
                use24HourClock = value;
            }
        }

        public clockDisplayControl()
        {
            InitializeComponent();
            updateClockAllDigits(DateTime.Now);
        }

        #region "Clock Display Updaters"

        /// <summary>
        /// Updates the clock.
        /// </summary>
        public void updateClock(DateTime currentDateTime)
        {
            updateClockSecondDigits(currentDateTime);

            if (currentDateTime.Second == 0)
            {
                updateClockMinuteDigits(currentDateTime);

                if (currentDateTime.Minute == 0)
                    updateClockHourDigits(currentDateTime);
            }
        }

        /// <summary>
        /// Updates the clock (all digits).
        /// </summary>
        public void updateClockAllDigits(DateTime currentDateTime)
        {
            updateClockSecondDigits(currentDateTime);
            updateClockMinuteDigits(currentDateTime);
            updateClockHourDigits(currentDateTime);
        }

        /// <summary>
        /// Updates the clock second digits.
        /// </summary>
        /// <param name="currentDateTime">The current date time.</param>
        private void updateClockSecondDigits(DateTime currentDateTime)
        {
            int secondOnes = 0;
            int secondTens = Math.DivRem(currentDateTime.Second, 10, out secondOnes);

            clockSecondSeperatorPictureBox.Image = displayGraphics.colonBitmap;
            clockSecondTensPictureBox.Image = displayGraphics.numericDigitBitmaps[secondTens];
            clockSecondOnesPictureBox.Image = displayGraphics.numericDigitBitmaps[secondOnes];
        }

        /// <summary>
        /// Updates the clock minute digits.
        /// </summary>
        /// <param name="currentDateTime">The current date time.</param>
        private void updateClockMinuteDigits(DateTime currentDateTime)
        {
            int minuteOnes = 0;
            int minuteTens = Math.DivRem(currentDateTime.Minute, 10, out minuteOnes);

            clockMinuteSeperatorPictureBox.Image = displayGraphics.colonBitmap;
            clockMinuteTensPictureBox.Image = displayGraphics.numericDigitBitmaps[minuteTens];
            clockMinutesOnesPictureBox.Image = displayGraphics.numericDigitBitmaps[minuteOnes];
        }

        /// <summary>
        /// Updates the clock hour digits.
        /// </summary>
        /// <param name="currentDateTime">The current date time.</param>
        private void updateClockHourDigits(DateTime currentDateTime)
        {
            int hour = updateClockTimeMode(currentDateTime);

            int hourOnes = 0;
            int hourTens = Math.DivRem(hour, 10, out hourOnes);

            if (use24HourClock || hourTens > 0)
                clockHourTensPictureBox.Image = displayGraphics.numericDigitBitmaps[hourTens];
            else
                clockHourTensPictureBox.Image = displayGraphics.blankDigitBitmap;

            clockHourOnesPictureBox.Image = displayGraphics.numericDigitBitmaps[hourOnes];
        }

        /// <summary>
        /// Updates the clock time mode.
        /// </summary>
        /// <param name="currentDateTime">The current date time.</param>
        /// <returns></returns>
        private int updateClockTimeMode(DateTime currentDateTime)
        {
            int hour = currentDateTime.Hour;

            // Initialize the time display.
            if (use24HourClock)
            {
                clockTimeModePictureBox.Image = displayGraphics.time24HourBitmap;
            }
            else
            {
                if (hour > 12)
                {
                    clockTimeModePictureBox.Image = displayGraphics.timePMBitmap;
                    hour -= 12;
                }
                else if (hour == 12)
                {
                    clockTimeModePictureBox.Image = displayGraphics.timePMBitmap;
                    hour = 12;
                }
                else if (hour == 0)
                {
                    clockTimeModePictureBox.Image = displayGraphics.timeAMBitmap;
                    hour = 12;
                }
                else
                {
                    clockTimeModePictureBox.Image = displayGraphics.timeAMBitmap;
                }
            }

            return hour;
        }

        #endregion

        #region "Time Context Menu Event Handlers"

        /// <summary>
        /// Handles the Click event of the use24hourClockToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void use24hourClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            use24HourClock = !use24HourClock;
            use24hourClockToolStripMenuItem.Checked = use24HourClock;
            updateClockAllDigits(DateTime.Now);
        }

        #endregion
    }
}