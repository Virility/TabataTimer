using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TabataTimerApplication.Core.Helpers
{
    public class TabataTimer : IDisposable
    {
        private CancellationTokenSource _cancellationTokenSource;

        public delegate void OnPreparingStoppedOrFinshedHandler(TimeSpan time);
        public event OnPreparingStoppedOrFinshedHandler OnPreparing;
        public event OnPreparingStoppedOrFinshedHandler OnStopped;
        public event OnPreparingStoppedOrFinshedHandler OnFinished;

        public delegate void OnRoundStartedAndRestingHandler(int round, TimeSpan time, TimeSpan elapsed);
        public event OnRoundStartedAndRestingHandler OnRoundStarted;
        public event OnRoundStartedAndRestingHandler OnRoundResting;

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
                    OnRoundStarted?.Invoke(round, TimeOn, stopwatch.Elapsed);
                    await Task.Delay(TimeOn, cancellationToken);

                    if (round == Rounds)
                        break;

                    OnRoundResting?.Invoke(round, TimeOff, stopwatch.Elapsed);
                    await Task.Delay(TimeOff, cancellationToken);
                }
            }
            catch (Exception)
            {
                stopwatch.Stop();
                OnStopped?.Invoke(stopwatch.Elapsed);
                
                Dispose();
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
