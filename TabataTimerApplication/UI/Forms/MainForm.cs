using System;
using System.Drawing;
using System.Windows.Forms;
using TabataTimerApplication.Core.Helpers;
using TabataTimerApplication.UI.Helpers;
using TabataTimerApplication.UI.Models;

namespace TabataTimerApplication.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly string[] _labelFormats =
        {
            "Rounds ({0})",
            "Preparation ({0} seconds)",
            "Time On ({0} seconds)",
            "Time Off ({0} seconds)"
        };

        private readonly RichTextBoxLogProvider _mainLogProvider;

        private TabataTimer _tabataTimer;

        public MainForm()
        {
            InitializeComponent();
            InvalidateLabels();

            _mainLogProvider = new RichTextBoxLogProvider(rtbMain);
        }

        private void TrackBarValuesChanged(object sender, EventArgs e)
        {
            InvalidateLabels();
        }

        private void InvalidateLabels()
        {
            lRounds.Text = string.Format(_labelFormats[0], tbRounds.Value);
            lPreparation.Text = string.Format(_labelFormats[1], tbPreparation.Value);
            lTimeOn.Text = string.Format(_labelFormats[2], tbTimeOn.Value);
            lTimeOff.Text = string.Format(_labelFormats[3], tbTimeOff.Value);
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            if (bStart.Text == "Start")
            {
                bStart.Text = "Stop";

                _tabataTimer = new TabataTimer
                {
                    Rounds = tbRounds.Value,
                    PreparationTime = new TimeSpan(0, 0, tbPreparation.Value),
                    TimeOn = new TimeSpan(0, 0, tbTimeOn.Value),
                    TimeOff = new TimeSpan(0, 0, tbTimeOff.Value),
                };

                _tabataTimer.OnPreparing += OnPreparing;
                _tabataTimer.OnRoundStarted += OnRoundStarted;
                _tabataTimer.OnRoundResting += OnRoundResting;
                _tabataTimer.OnStopped += OnStopped;
                _tabataTimer.OnFinished += OnFinished;

                _mainLogProvider.Log(LogItem.Create("Started timer."));
                var entries = new[]
                {
                    new LogEntry("Expected to take ", true, false),
                    new LogEntry($"{(_tabataTimer.TotalWorkoutTime + _tabataTimer.PreparationTime).TotalSeconds:N0}", false, false, SystemColors.Highlight),
                    new LogEntry(" seconds.", false),
                };
                _mainLogProvider.Log(LogItem.Create(entries));

                await _tabataTimer.Start();
            }
            else
            {
                _tabataTimer.Stop();
                bStart.Text = "Start";
            }
        }

        private void OnPreparing(TimeSpan time)
        {
            var entries = new[]
            {
                new LogEntry("Preparing for ", true, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));
        }

        private void OnRoundStarted(int round, TimeSpan time, TimeSpan elapsed)
        {
            Console.Beep(3000, 200);

            var entries = new[]
            {
                new LogEntry("Started round ", true, false),
                new LogEntry($"#{round}", false, false, SystemColors.Highlight),
                new LogEntry(" for ", false, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));
        }

        private void OnRoundResting(int round, TimeSpan time, TimeSpan elapsed)
        {
            Console.Beep(3000, 500);

            var entries = new[]
            {
                new LogEntry("Resting after round ", true, false),
                new LogEntry($"#{round}", false, false, SystemColors.Highlight),
                new LogEntry(" for ", false, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));
        }

        private void OnStopped(TimeSpan time)
        {
            var entries = new[]
            {
                new LogEntry("Stopped after ", true, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));

            bStart.Text = "Stop";
        }

        private void OnFinished(TimeSpan time)
        {
            Console.Beep(1500, 1000);

            var entries = new[]
            {
                new LogEntry("Finished in ", true, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));

            bStart.Text = "Stop";
        }
    }
}
