using System;
using System.Threading;
using System.Threading.Tasks;
using KegelTimerApplication.Core.Models;

namespace KegelTimerApplication.Core.Helpers.Timers
{
    public abstract class KegelTimer : IDisposable
    {
        protected CancellationTokenSource CancellationTokenSource { get; set; }

        public delegate void ReportTimeHandler(TimeSpan time);
        public event ReportTimeHandler Preparing;
        public event ReportTimeHandler Stopped;
        public event ReportTimeHandler Finished;

        public delegate void ReportUpdateHandler(ReportUpdateEventArgs eventArgs);
        public event ReportUpdateHandler RoundStarted;
        public event ReportUpdateHandler RoundResting;

        public int Rounds { get; set; } = 10;

        public TimeSpan TimeOn { get; set; }

        public TimeSpan TimeOff { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public virtual TimeSpan TotalWorkoutTime { get; }

        protected KegelTimer()
        {
            TimeOn = new TimeSpan(0, 0, 10);
            TimeOff = new TimeSpan(0, 0, 10);
            PreparationTime = new TimeSpan(0, 0, 10);
        }


        protected virtual void OnPreparing(TimeSpan time)
        {
            Preparing?.Invoke(time);
        }

        protected virtual void OnStopped(TimeSpan time)
        {
            Stopped?.Invoke(time);
        }

        protected virtual void OnFinished(TimeSpan time)
        {
            Finished?.Invoke(time);
        }


        protected virtual void OnRoundStarted(ReportUpdateEventArgs eventArgs)
        {
            RoundStarted?.Invoke(eventArgs);
        }

        protected virtual void OnRoundResting(ReportUpdateEventArgs eventArgs)
        {
            RoundResting?.Invoke(eventArgs);
        }


        public virtual async Task Start() { }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (CancellationTokenSource == null)
                return;

            try
            {
                CancellationTokenSource.Cancel();
            }
            catch (AggregateException) { }

            CancellationTokenSource.Dispose();
        }
    }
}
