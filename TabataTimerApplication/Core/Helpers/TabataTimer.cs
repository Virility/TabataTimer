using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TabataTimerApplication.Core.Helpers
{
    public class TabataTimer
    {
        private readonly CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

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
                var totalTimeOff = TimeSpan.FromTicks(TimeOff.Ticks * Rounds);

                return totalTimeOn + totalTimeOff;
            }
        }

        public TabataTimer()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            TimeOn = new TimeSpan(0, 0, 10);
            TimeOff = new TimeSpan(0, 0, 10);
            PreparationTime = new TimeSpan(0, 0, 10);
        }

        public async Task Start()
        {
            _cancellationToken = _cancellationTokenSource.Token;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                if (PreparationTime.Seconds != 0)
                {
                    OnPreparing?.Invoke(PreparationTime);
                    await Task.Delay(PreparationTime, _cancellationToken);
                }
            
                for (var round = 1; round < Rounds + 1; round++)
                {
                    OnRoundStarted?.Invoke(round, TimeOn, stopwatch.Elapsed);
                    await Task.Delay(TimeOn, _cancellationToken);

                    if (round == Rounds)
                        break;

                    OnRoundResting?.Invoke(round, TimeOff, stopwatch.Elapsed);
                    await Task.Delay(TimeOff, _cancellationToken);
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
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}