using System;
using System.Diagnostics;

namespace ArrangeActAssert.Configuration.Time
{
    public sealed class StopwatchTimer : IStopwatch
    {
        private Stopwatch _stopwatch = new Stopwatch();
        public void Start() => _stopwatch.Start();
        public void ReStart() => _stopwatch.Restart();
        public void Stop() => _stopwatch.Stop();
        public TimeSpan Elapsed() => _stopwatch.Elapsed;
    }
}