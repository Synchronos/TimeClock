using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Timers;

namespace TimeclockControls
{
    public partial class clockTimerControl : UserControl
    {
        // Flags
        private bool _isSplit = false;
        private bool _isPaused = false;
        private bool _isRunning = false;

        // Date & Time Handling
        private DateTime _startDateTime;
        private Stopwatch _stopwatch = new Stopwatch();
        private readonly object _lockReference = new object();
        private TimeSpan _elapsedTimeSpan = TimeSpan.Zero;
        /// <summary>
        /// Gets or sets the elapsed time span.
        /// </summary>
        /// <value>The elapsed time span.</value>
        private TimeSpan ElapsedTimeSpan
        {
            get
            {
                lock (_lockReference)
                {
                    return _elapsedTimeSpan;
                }
            }
            set
            {
                lock (_lockReference)
                {
                    _elapsedTimeSpan = value;
                }
            }
        }

        public clockTimerControl()
        {
            InitializeComponent();

        }

        #region "Timer Button Event Handlers"

        /// <summary>
        /// Handles the Click event of the startPauseOrResumeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void startPauseOrResumeButton_Click(object sender, System.EventArgs e)
        {
            startPauseOrResumeTimer();
        }

        /// <summary>
        /// Handles the Click event of the stopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void stopButton_Click(object sender, System.EventArgs e)
        {
            stopTimer();
        }

        /// <summary>
        /// Handles the Click event of the splitUnsplitOrClearButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void splitUnsplitOrClearButton_Click(object sender, System.EventArgs e)
        {
            splitUnsplitOrClearTimer();
        }

        #endregion

        #region "Timer Control Methods"

        /// <summary>
        /// Starts, pauses, or resumes the timer.
        /// </summary>
        private void startPauseOrResumeTimer()
        {
            if (!this._isRunning && !this._isSplit)
            {
                startTimer();
            }
            else if (this._isRunning && !this._isPaused)
            {
                pauseTimer();
            }
            else if (this._isRunning && this._isPaused)
            {
                resumeTimer();
            }
        }

        public event EventHandler<EventArgs> TimerResumed;
        /// <summary>
        /// Resumes the timer.
        /// </summary>
        private void resumeTimer()
        {
            // This restarts the paused timer.
            this._stopwatch.Start();
            this.ElapsedTimeSpan = this._stopwatch.Elapsed;
            this._startDateTime = DateTime.Now;
            this._isPaused = false;
            this.startPauseOrResumeButton.Text = "Pause";

            timeElapsedTimeDisplayControl.updateElapsedTimeAllDigits(this.ElapsedTimeSpan);
            timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(_startDateTime, _isPaused, _isSplit);

            if (TimerResumed != null)
                TimerResumed(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerPaused;
        /// <summary>
        /// Pauses the timer.
        /// </summary>
        private void pauseTimer()
        {
            // This pauses the running timer.
            this._stopwatch.Stop();
            _isPaused = true;
            this.startPauseOrResumeButton.Text = "Resume";

            if (TimerPaused != null)
                TimerPaused(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerStarted;
        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void startTimer()
        {
            this._stopwatch.Reset();
            this._stopwatch.Start();
            this.ElapsedTimeSpan = this._stopwatch.Elapsed;
            this._startDateTime = DateTime.Now;
            this.startPauseOrResumeButton.Text = "Pause";
            this.splitUnsplitOrClearButton.Text = "Split";
            this._isPaused = false;
            this._isRunning = true;

            if (TimerStarted != null)
                TimerStarted(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerStopped;
        /// <summary>
        /// Stops the timer.
        /// </summary>
        private void stopTimer()
        {
            this._isRunning = false;
            this._isPaused = false;
            this.ElapsedTimeSpan = this._stopwatch.Elapsed;

            this._stopwatch.Stop();

            if (_isSplit)
            {
                this.startPauseOrResumeButton.Text = "--";
                this.startPauseOrResumeButton.Enabled = false;
                this.splitUnsplitOrClearButton.Text = "Unsplit";
                timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(DateTime.Now, _isPaused, _isSplit);
            }
            else
            {
                this.startPauseOrResumeButton.Text = "Start";
                this.startPauseOrResumeButton.Enabled = true;
                this.splitUnsplitOrClearButton.Text = "Clear";
                timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(DateTime.Now, _isPaused, _isSplit);
            }

            if (TimerStopped != null)
                TimerStopped(this, EventArgs.Empty);
        }

        /// <summary>
        /// Splits the timer.
        /// </summary>
        private void splitUnsplitOrClearTimer()
        {
            // If the timer has been splite, unsplit the timer.
            if (_isSplit)
            {
                unsplitTimer();
            }
            // If the timer has been stopped and is not split, clear the display and zero the elapsed time stored.
            else if (!this._isRunning)
            {
                clearTimer();
            }
            // If the timer is running normally, split the display. (The timer will continue counting without display updates.)
            else
            {
                splitTimer();
            }
        }

        public event EventHandler<EventArgs> TimerSplit;
        /// <summary>
        /// Splits the timer.
        /// </summary>
        private void splitTimer()
        {
            _isSplit = true;
            this.splitUnsplitOrClearButton.Text = "Unsplit";

            if (TimerSplit != null)
                TimerSplit(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerClear;
        /// <summary>
        /// Clears the timer.
        /// </summary>
        private void clearTimer()
        {
            this.ElapsedTimeSpan = TimeSpan.Zero;
            this.startPauseOrResumeButton.Text = "Start";

            timeElapsedTimeDisplayControl.blankElapsedTime();

            if (TimerClear != null)
                TimerClear(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerUnsplit;
        /// <summary>
        /// Unsplits the timer.
        /// </summary>
        private void unsplitTimer()
        {
            // This handles unsplitting the display.
            this._isSplit = false;
            this.startPauseOrResumeButton.Enabled = true;

            // Change the buttons as appropriate.
            if (!this._isRunning)
            {
                this.splitUnsplitOrClearButton.Text = "Clear";
                this.startPauseOrResumeButton.Text = "Start";
            }
            else
            {
                this.splitUnsplitOrClearButton.Text = "Split";
            }

            // Always update the display when coming back from being split because the normal update
            // is optimized to only update certain digits.
            this.ElapsedTimeSpan = this._stopwatch.Elapsed;

            timeElapsedTimeDisplayControl.updateElapsedTimeAllDigits(ElapsedTimeSpan);

            if (TimerUnsplit != null)
                TimerUnsplit(this, EventArgs.Empty);
        }

        #endregion

        #region "Public properties and methods for checking state."
        /// <summary>
        /// Gets the elapsed time.
        /// </summary>
        /// <returns></returns>
        public TimeSpan GetElapsedTime()
        {
            return ElapsedTimeSpan;
        }

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <returns></returns>
        public DateTime GetStartDate()
        {
            return _startDateTime;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is running.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is running; otherwise, <c>false</c>.
        /// </value>
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is split.
        /// </summary>
        /// <value><c>true</c> if this instance is split; otherwise, <c>false</c>.</value>
        public bool IsSplit
        {
            get
            {
                return _isSplit;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is paused.
        /// </summary>
        /// <value><c>true</c> if this instance is paused; otherwise, <c>false</c>.</value>
        public bool IsPaused
        {
            get
            {
                return _isPaused;
            }
        }
        #endregion

        public event EventHandler<ElapsedEventArgs> Elapsed;
        /// <summary>
        /// Handles the Elapsed event of the updateTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void updateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(currentDateTime, _isPaused, _isSplit);

            if (!this._isSplit)
                timeElapsedTimeDisplayControl.updateElapsedTime(ElapsedTimeSpan);

            timeclockDisplayControl.updateClock(currentDateTime);

            if (_isRunning)
            {
                this.ElapsedTimeSpan = this._stopwatch.Elapsed;
            }

            if (Elapsed != null)
                Elapsed(this, e);

        }
    }
}
