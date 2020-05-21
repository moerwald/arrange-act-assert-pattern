using System;

namespace ArrangeActAssert.Configuration.Time
{
    public interface IStopwatch
    {
        TimeSpan Elapsed();
        void ReStart();
        void Start();
        void Stop();
    }
}