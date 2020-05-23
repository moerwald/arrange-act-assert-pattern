using System;

namespace ArrangeActAssert.Environment.Time
{
    public interface IStopwatch
    {
        TimeSpan Elapsed();
        void ReStart();
        void Start();
        void Stop();
    }
}