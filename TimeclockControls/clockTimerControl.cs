using System;
using System.Windows.Forms;
using System.Timers;
using TimeclockControls.Abstractions;

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
        private readonly IStopwatchAdapter _stopwatch;
        private readonly ITimeProvider _timeProvider;
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

        public clockTimerControl() : this(new StopwatchAdapter(), new SystemTimeProvider()) { }

        /// <summary>
        /// Initializes a new instance of <see cref="clockTimerControl"/> with injectable dependencies.
        /// Intended for use in unit tests via the <c>TimeclockControls.Abstractions</c> fakes.
        /// </summary>
        public clockTimerControl(IStopwatchAdapter stopwatch, ITimeProvider timeProvider)
        {
            _stopwatch = stopwatch;
            _timeProvider = timeProvider;
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
            if (!_isRunning && !_isSplit)
            {
                startTimer();
            }
            else if (_isRunning && !_isPaused)
            {
                pauseTimer();
            }
            else if (_isRunning && _isPaused)
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
            _stopwatch.Start();
            ElapsedTimeSpan = _stopwatch.Elapsed;
            // _startDateTime is intentionally not updated here to preserve the original start time.
            _isPaused = false;
            startPauseOrResumeButton.Text = "Pause";

            timeElapsedTimeDisplayControl.updateElapsedTimeAllDigits(ElapsedTimeSpan);
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
            _stopwatch.Stop();
            _isPaused = true;
            startPauseOrResumeButton.Text = "Resume";

            if (TimerPaused != null)
                TimerPaused(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerStarted;
        /// <summary>
        /// Starts the timer.
        /// </summary>
        private void startTimer()
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            ElapsedTimeSpan = _stopwatch.Elapsed;
            _startDateTime = _timeProvider.Now;
            startPauseOrResumeButton.Text = "Pause";
            splitUnsplitOrClearButton.Text = "Split";
            _isPaused = false;
            _isRunning = true;

            if (TimerStarted != null)
                TimerStarted(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerStopped;
        /// <summary>
        /// Stops the timer.
        /// </summary>
        private void stopTimer()
        {
            _isRunning = false;
            _isPaused = false;
            ElapsedTimeSpan = _stopwatch.Elapsed;

            _stopwatch.Stop();

            if (_isSplit)
            {
                startPauseOrResumeButton.Text = "--";
                startPauseOrResumeButton.Enabled = false;
                splitUnsplitOrClearButton.Text = "Unsplit";
                timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(DateTime.Now, _isPaused, _isSplit);
            }
            else
            {
                startPauseOrResumeButton.Text = "Start";
                startPauseOrResumeButton.Enabled = true;
                splitUnsplitOrClearButton.Text = "Clear";
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
            else if (!_isRunning)
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
            splitUnsplitOrClearButton.Text = "Unsplit";

            if (TimerSplit != null)
                TimerSplit(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> TimerClear;
        /// <summary>
        /// Clears the timer.
        /// </summary>
        private void clearTimer()
        {
            ElapsedTimeSpan = TimeSpan.Zero;
            startPauseOrResumeButton.Text = "Start";

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
            _isSplit = false;
            startPauseOrResumeButton.Enabled = true;

            // Change the buttons as appropriate.
            if (!_isRunning)
            {
                splitUnsplitOrClearButton.Text = "Clear";
                startPauseOrResumeButton.Text = "Start";
            }
            else
            {
                splitUnsplitOrClearButton.Text = "Split";
            }

            // Always update the display when coming back from being split because the normal update
            // is optimized to only update certain digits.
            ElapsedTimeSpan = _stopwatch.Elapsed;

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

        #region "Internal test helpers"
        // These methods expose private timer actions for integration testing.
        // They are internal and visible to Timeclock.Tests via InternalsVisibleTo.
        internal void TestStart()   => startTimer();
        internal void TestPause()   => pauseTimer();
        internal void TestResume()  => resumeTimer();
        internal void TestStop()    => stopTimer();
        internal void TestSplit()   => splitTimer();
        internal void TestUnsplit() => unsplitTimer();
        internal void TestClear()   => clearTimer();
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

            // Update ElapsedTimeSpan first so the display and Elapsed event see the current value.
            if (_isRunning)
            {
                ElapsedTimeSpan = _stopwatch.Elapsed;
            }

            timeElapsedTimeDisplayControl.updateElapsedTimeDigitSeperators(currentDateTime, _isPaused, _isSplit);

            if (!_isSplit)
                timeElapsedTimeDisplayControl.updateElapsedTime(ElapsedTimeSpan);

            timeclockDisplayControl.updateClock(currentDateTime);

            if (Elapsed != null)
                Elapsed(this, e);

        }
    }
}
