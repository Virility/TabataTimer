using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using KegelTimerApplication.Core.Models;

namespace KegelTimerApplication.Core.Helpers.Timers
{
    public class LongerLastRoundTimer : KegelTimer
    {
        public TimeSpan LastRoundTime { get; set; }

        public override TimeSpan TotalWorkoutTime
        {
            get
            {
                var totalTimeOn = TimeSpan.FromTicks(TimeOn.Ticks * (Rounds - 1) + LastRoundTime.Ticks);
                var totalTimeOff = TimeSpan.FromTicks(TimeOff.Ticks * (Rounds - 1));

                return totalTimeOn + totalTimeOff;
            }
        }

        public LongerLastRoundTimer()
        {
            LastRoundTime = new TimeSpan(0, 0, 10);
        }

        public override async Task Start()
        {
            CancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = CancellationTokenSource.Token;

            var stopwatch = Stopwatch.StartNew();

            try
            {
                if (PreparationTime.Seconds != 0)
                {
                    OnPreparing(PreparationTime);
                    await Task.Delay(PreparationTime, cancellationToken);
                }

                ReportUpdateEventArgs eventArgs;
                for (var round = 1; round < Rounds; round++)
                {
                    eventArgs = new ReportUpdateEventArgs(round, TimeOn, stopwatch.Elapsed);
                    OnRoundStarted(eventArgs);
                    await Task.Delay(TimeOn, cancellationToken);

                    if (round == Rounds)
                        break;

                    eventArgs = new ReportUpdateEventArgs(round, TimeOff, stopwatch.Elapsed);
                    OnRoundResting(eventArgs);
                    await Task.Delay(TimeOff, cancellationToken);
                }

                eventArgs = new ReportUpdateEventArgs(Rounds, LastRoundTime, stopwatch.Elapsed);
                OnRoundStarted(eventArgs);
                await Task.Delay(LastRoundTime, cancellationToken);
            }
            catch (Exception)
            {
                stopwatch.Stop();
                OnStopped(stopwatch.Elapsed);
                return;
            }

            stopwatch.Stop();
            OnFinished(stopwatch.Elapsed);

            Dispose();
        }
    }
}
