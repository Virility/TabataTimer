using System;

namespace KegelTimerApplication.Core.Models
{
    public class ReportUpdateEventArgs : EventArgs
    {
        public int Round { get; set; }

        public TimeSpan Time { get; set; }

        public TimeSpan Elapsed { get; set; }

        public ReportUpdateEventArgs(int round, TimeSpan time, TimeSpan elapsed)
        {
            Round = round;
            Time = time;
            Elapsed = elapsed;
        }
    }
}