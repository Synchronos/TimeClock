namespace TimeclockControls
{
    partial class clockTimerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startPauseOrResumeButton = new System.Windows.Forms.Button();
            this.splitUnsplitOrClearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.timeElapsedTimeDisplayControl = new TimeclockControls.elapsedTimeDisplayControl();
            this.timeclockDisplayControl = new TimeclockControls.clockDisplayControl();
            this.updateTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.updateTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // startPauseOrResumeButton
            // 
            this.startPauseOrResumeButton.BackColor = System.Drawing.Color.Brown;
            this.startPauseOrResumeButton.CausesValidation = false;
            this.startPauseOrResumeButton.ForeColor = System.Drawing.Color.White;
            this.startPauseOrResumeButton.Location = new System.Drawing.Point(13, 123);
            this.startPauseOrResumeButton.Name = "startPauseOrResumeButton";
            this.startPauseOrResumeButton.Size = new System.Drawing.Size(56, 24);
            this.startPauseOrResumeButton.TabIndex = 18;
            this.startPauseOrResumeButton.Text = "Start";
            this.startPauseOrResumeButton.UseVisualStyleBackColor = false;
            this.startPauseOrResumeButton.Click += new System.EventHandler(this.startPauseOrResumeButton_Click);
            // 
            // splitUnsplitOrClearButton
            // 
            this.splitUnsplitOrClearButton.BackColor = System.Drawing.Color.Brown;
            this.splitUnsplitOrClearButton.CausesValidation = false;
            this.splitUnsplitOrClearButton.ForeColor = System.Drawing.Color.White;
            this.splitUnsplitOrClearButton.Location = new System.Drawing.Point(49, 153);
            this.splitUnsplitOrClearButton.Name = "splitUnsplitOrClearButton";
            this.splitUnsplitOrClearButton.Size = new System.Drawing.Size(68, 24);
            this.splitUnsplitOrClearButton.TabIndex = 20;
            this.splitUnsplitOrClearButton.Text = "Clear";
            this.splitUnsplitOrClearButton.UseVisualStyleBackColor = false;
            this.splitUnsplitOrClearButton.Click += new System.EventHandler(this.splitUnsplitOrClearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.Brown;
            this.stopButton.CausesValidation = false;
            this.stopButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.stopButton.ForeColor = System.Drawing.Color.White;
            this.stopButton.Location = new System.Drawing.Point(101, 123);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(56, 24);
            this.stopButton.TabIndex = 19;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // timeElapsedTimeDisplayControl
            // 
            this.timeElapsedTimeDisplayControl.BackColor = System.Drawing.Color.Transparent;
            this.timeElapsedTimeDisplayControl.Location = new System.Drawing.Point(3, 63);
            this.timeElapsedTimeDisplayControl.Name = "timeElapsedTimeDisplayControl";
            this.timeElapsedTimeDisplayControl.Size = new System.Drawing.Size(166, 54);
            this.timeElapsedTimeDisplayControl.TabIndex = 1;
            // 
            // timeclockDisplayControl
            // 
            this.timeclockDisplayControl.BackColor = System.Drawing.Color.Transparent;
            this.timeclockDisplayControl.Location = new System.Drawing.Point(3, 3);
            this.timeclockDisplayControl.Name = "timeclockDisplayControl";
            this.timeclockDisplayControl.Size = new System.Drawing.Size(166, 54);
            this.timeclockDisplayControl.TabIndex = 0;
            this.timeclockDisplayControl.Use24HourClock = false;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.SynchronizingObject = this;
            this.updateTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.updateTimer_Elapsed);
            // 
            // clockTimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.startPauseOrResumeButton);
            this.Controls.Add(this.splitUnsplitOrClearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.timeElapsedTimeDisplayControl);
            this.Controls.Add(this.timeclockDisplayControl);
            this.Name = "clockTimerControl";
            this.Size = new System.Drawing.Size(172, 180);
            ((System.ComponentModel.ISupportInitialize)(this.updateTimer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private clockDisplayControl timeclockDisplayControl;
        private elapsedTimeDisplayControl timeElapsedTimeDisplayControl;
        private System.Windows.Forms.Button startPauseOrResumeButton;
        private System.Windows.Forms.Button splitUnsplitOrClearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Timers.Timer updateTimer;
    }
}
