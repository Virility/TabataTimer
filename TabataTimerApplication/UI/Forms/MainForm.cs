using System;
using System.Drawing;
using System.Windows.Forms;
using KegelTimerApplication.Core.Helpers.Timers;
using KegelTimerApplication.Core.Models;
using KegelTimerApplication.UI.Helpers;
using KegelTimerApplication.UI.Models;

namespace KegelTimerApplication.UI.Forms
{
    public partial class MainForm : Form
    {
        private readonly string[] _labelFormats =
        {
            "Rounds ({0})",
            "Preparation Time ({0} seconds)",
            "On Time ({0} seconds)",
            "Off Time ({0} seconds)",
            "Last Round Time ({0} seconds)"
        };

        private readonly RichTextBoxLogProvider _mainLogProvider;

        private KegelTimer _kegelTimer;

        public MainForm(IniFile configurationFile)
        {
            InitializeComponent();
            InvalidateLabels();

            _mainLogProvider = new RichTextBoxLogProvider(rtbMain);
            ProcessConfigurationFile(configurationFile);
        }

        private void ProcessConfigurationFile(IniFile configurationFile)
        {
            if (configurationFile == null)
                return;

            if (int.TryParse(configurationFile.IniReadValue("Kegel", "Rounds"), out var tempVariable))
                tbRounds.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Kegel", "PreparationTime"), out tempVariable))
                tbPreparationTime.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Kegel", "OnTime"), out tempVariable))
                tbOnTime.Value = tempVariable;

            if (int.TryParse(configurationFile.IniReadValue("Kegel", "OffTime"), out tempVariable))
                tbOffTime.Value = tempVariable;

            if (!bool.TryParse(configurationFile.IniReadValue("LongerTime", "Enabled"), out var tempVariable2))
                return;

            ToggleLongerLastRoundTime(!tempVariable2);
            if (int.TryParse(configurationFile.IniReadValue("LongerTime", "Time"), out tempVariable))
                tbLongerLastRoundTime.Value = tempVariable;
        }

        private void InvalidateLabels()
        {
            lRounds.Text = string.Format(_labelFormats[0], tbRounds.Value);
            lPreparationTime.Text = string.Format(_labelFormats[1], tbPreparationTime.Value);
            lOnTime.Text = string.Format(_labelFormats[2], tbOnTime.Value);
            lOffTime.Text = string.Format(_labelFormats[3], tbOffTime.Value);
            lLongerLastRoundTime.Text = string.Format(_labelFormats[4], tbLongerLastRoundTime.Value);
        }

        private async void bStart_Click(object sender, EventArgs e)
        {
            if (bStart.Text == "Start")
            {
                bStart.Text = "Stop";

                if (lLongerLastRoundTime.Enabled)
                {
                    _kegelTimer = new LongerLastRoundTimer
                    {
                        Rounds = tbRounds.Value,
                        PreparationTime = new TimeSpan(0, 0, tbPreparationTime.Value),
                        TimeOn = new TimeSpan(0, 0, tbOnTime.Value),
                        TimeOff = new TimeSpan(0, 0, tbOffTime.Value),
                        LastRoundTime = new TimeSpan(0, 0, tbLongerLastRoundTime.Value)
                    };
                }
                else
                {
                    _kegelTimer = new NormalTimer
                    {
                        Rounds = tbRounds.Value,
                        PreparationTime = new TimeSpan(0, 0, tbPreparationTime.Value),
                        TimeOn = new TimeSpan(0, 0, tbOnTime.Value),
                        TimeOff = new TimeSpan(0, 0, tbOffTime.Value)
                    };
                }

                _kegelTimer.Preparing += OnPreparing;
                _kegelTimer.RoundStarted += OnRoundStarted;
                _kegelTimer.RoundResting += OnRoundResting;
                _kegelTimer.Stopped += OnStopped;
                _kegelTimer.Finished += OnFinished;

                var totalExpectedTime = _kegelTimer.TotalWorkoutTime + _kegelTimer.PreparationTime;
                var entries = new[]
                {
                    new LogEntry("Expected to take ", true, false),
                    new LogEntry($"{totalExpectedTime.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                    new LogEntry(" seconds.", false),
                };
                _mainLogProvider.Log(LogItem.Create(entries));

                _mainLogProvider.Log(LogItem.Create("Started timer."));
                await _kegelTimer.Start();
            }
            else
            {
                _kegelTimer.Stop();
                bStart.Text = "Start";
            }
        }

        private void TrackBarValuesChanged(object sender, EventArgs e)
        {
            InvalidateLabels();
        }

        private void ToggleLongerLastRoundTime(bool enabled)
        {
            if (enabled)
            {
                lLongerLastRoundTime.Enabled =
                    tbLongerLastRoundTime.Enabled = false;
                lLongerLastRoundTimeToggle.Text = "Enable";
                lLongerLastRoundTimeToggle.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                lLongerLastRoundTime.Enabled =
                    tbLongerLastRoundTime.Enabled = true;
                lLongerLastRoundTimeToggle.Text = "Disable";
                lLongerLastRoundTimeToggle.ForeColor = SystemColors.ControlText;
            }
        }

        private void lLongerLastRoundTimeToggle_Click(object sender, EventArgs e)
        {
            ToggleLongerLastRoundTime(lLongerLastRoundTime.Enabled);
        }

        private void OnPreparing(TimeSpan time)
        {
            var entries = new[]
            {
                new LogEntry("Preparing for ", true, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false)
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
                new LogEntry(" seconds.", false)
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
                new LogEntry(" seconds.", false)
            };
            _mainLogProvider.Log(LogItem.Create(entries));
        }

        private void OnStopped(TimeSpan time)
        {
            var entries = new[]
            {
                new LogEntry("Stopped after ", true, false),
                new LogEntry($"{time.TotalSeconds:N0}", false, false, SystemColors.Highlight),
                new LogEntry(" seconds.", false)
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
                new LogEntry(" seconds.", false)
            };
            _mainLogProvider.Log(LogItem.Create(entries));

            bStart.Text = "Start";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var configurationFile = new IniFile(Config.ConfigurationFilePath);
            configurationFile.IniWriteValue("Kegel", "Rounds", tbRounds.Value.ToString());
            configurationFile.IniWriteValue("Kegel", "PreparationTime", tbPreparationTime.Value.ToString());
            configurationFile.IniWriteValue("Kegel", "OnTime", tbOnTime.Value.ToString());
            configurationFile.IniWriteValue("Kegel", "OffTime", tbOffTime.Value.ToString());
            configurationFile.IniWriteValue("LongerTime", "Enabled", lLongerLastRoundTimeToggle.Enabled.ToString());
            configurationFile.IniWriteValue("LongerTime", "Time", tbLongerLastRoundTime.Value.ToString());
        }
    }
}