using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TabataTimerApplication.Core.Models;

namespace TabataTimerApplication.Core.Helpers
{
    public class TabataTimer : IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;

        public delegate void ReportTimeHandler(TimeSpan time);
        public event ReportTimeHandler OnPreparing;
        public event ReportTimeHandler OnStopped;
        public event ReportTimeHandler OnFinished;

        public delegate void ReportUpdateHandler(ReportUpdateEventArgs eventArgs);
        public event ReportUpdateHandler OnRoundStarted;
        public event ReportUpdateHandler OnRoundResting;

        public int Rounds { get; set; } = 10;

        public TimeSpan TimeOn { get; set; }

        public TimeSpan TimeOff { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan TotalWorkoutTime
        {
            get
            {
                var totalTimeOn = TimeSpan.FromTicks(TimeOn.Ticks * Rounds);
                var totalTimeOff = TimeSpan.FromTicks(TimeOff.Ticks * (Rounds - 1));

                return totalTimeOn + totalTimeOff;
            }
        }

        public TabataTimer()
        {
            TimeOn = new TimeSpan(0, 0, 10);
            TimeOff = new TimeSpan(0, 0, 10);
            PreparationTime = new TimeSpan(0, 0, 10);
        }

        public async Task Start()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            var stopwatch = Stopwatch.StartNew();

            try
            {
                if (PreparationTime.Seconds != 0)
                {
                    OnPreparing?.Invoke(PreparationTime);
                    await Task.Delay(PreparationTime, cancellationToken);
                }
            
                for (var round = 1; round < Rounds + 1; round++)
                {
                    var eventArg = new ReportUpdateEventArgs(round, TimeOn, stopwatch.Elapsed);
                    OnRoundStarted?.Invoke(eventArg);
                    await Task.Delay(TimeOn, cancellationToken);

                    if (round == Rounds)
                        break;

                    eventArg = new ReportUpdateEventArgs(round, TimeOff, stopwatch.Elapsed);
                    OnRoundResting?.Invoke(eventArg);
                    await Task.Delay(TimeOff, cancellationToken);
                }
            }
            catch (Exception)
            {
                stopwatch.Stop();
                OnStopped?.Invoke(stopwatch.Elapsed);
                return;
            }

            stopwatch.Stop();
            OnFinished?.Invoke(stopwatch.Elapsed);

            Dispose();
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_cancellationTokenSource == null)
                return;

            try
            {
                _cancellationTokenSource.Cancel();
            }
            catch (AggregateException) { }

            _cancellationTokenSource.Dispose();
        }
    }
}
