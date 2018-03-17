using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TabataTimerApplication.Core.Helpers;
using TabataTimerApplication.Core.Models;
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

        public MainForm(INIFile configurationFile)
        {
            InitializeComponent();
            InvalidateLabels();

            _mainLogProvider = new RichTextBoxLogProvider(rtbMain);
            ProcessConfigurationFile(configurationFile);
        }

        private void ProcessConfigurationFile(INIFile configurationFile)
        {
            if (configurationFile == null)
                return;

            if (int.TryParse(configurationFile.IniReadValue("Main", "Rounds"), out var tempVariable))
                tbRounds.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Main", "PreparationTime"), out tempVariable))
                tbPreparation.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Main", "TimeOn"), out tempVariable))
                tbTimeOn.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Main", "TimeOff"), out tempVariable))
                tbTimeOff.Value = tempVariable;
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

                var totalExpectedTime = _tabataTimer.TotalWorkoutTime + _tabataTimer.PreparationTime;
                var entries = new[]
                {
                    new LogEntry("Expected to take ", true, false),
                    new LogEntry($"{totalExpectedTime.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                    new LogEntry(" seconds.", false),
                };
                _mainLogProvider.Log(LogItem.Create(entries));

                _mainLogProvider.Log(LogItem.Create("Started timer."));
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

        private void OnRoundStarted(ReportUpdateEventArgs eventArgs)
        {
            Console.Beep(3000, 200);

            var entries = new[]
            {
                new LogEntry("Started round ", true, false),
                new LogEntry($"#{eventArgs.Round}", false, false, SystemColors.Highlight),
                new LogEntry(" for ", false, false),
                new LogEntry($"{eventArgs.Time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false),
            };
            _mainLogProvider.Log(LogItem.Create(entries));
        }

        private void OnRoundResting(ReportUpdateEventArgs eventArgs)
        {
            Console.Beep(3000, 500);

            var entries = new[]
            {
                new LogEntry("Resting after round ", true, false),
                new LogEntry($"#{eventArgs.Round}", false, false, SystemColors.Highlight),
                new LogEntry(" for ", false, false),
                new LogEntry($"{eventArgs.Time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
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

            bStart.Text = "Start";
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

            bStart.Text = "Start";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var finalPath = Path.Combine(desktopPath, "default.ini");

            var configurationFile = new INIFile(finalPath);
            configurationFile.IniWriteValue("Main", "Rounds", tbRounds.Value.ToString());
            configurationFile.IniWriteValue("Main", "PreparationTime", tbPreparation.Value.ToString());
            configurationFile.IniWriteValue("Main", "TimeOn", tbTimeOn.Value.ToString());
            configurationFile.IniWriteValue("Main", "TimeOff", tbTimeOff.Value.ToString());
        }
    }
}