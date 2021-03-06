﻿using ArrangeActAssert.Environment.Time;
using System;

namespace ArrangeActAssert.Test.Invoker
{

    public class StopWatchDecorator : ChainableInvoke
    {

        private readonly IStopwatch _stopwatch;

        public StopWatchDecorator(IStopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        private static void LogInvocationTime(IInvokeableTestStep testStep, double timeEllapsed)
        {
            Console.WriteLine($"Test step run: {timeEllapsed} milliseconds. Test step description: {testStep.GetDescription()}");
        }

        protected override void BeforeInvoke(IInvokeableTestStep testStep)
        {
            _stopwatch.ReStart();
        }

        protected override void AfterInvoke(IInvokeableTestStep testStep)
        {
            _stopwatch.Stop();

            LogInvocationTime(testStep, _stopwatch.Elapsed().TotalMilliseconds);
        }
    }
}
