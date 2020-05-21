﻿using ArrangeActAssert.Arrange;
using ArrangeActAssert.Configuration.Time;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using ArrangeActAssert.Test.Invoker;
using LanguageExt;
using System;

namespace ArrangeActAssert.Configuration
{
    public class Configure : IConfigure
    {
        private BuildInvokeChain _buildInvokeChain = new BuildInvokeChain();

        public Configure() { }

        public IConfigure MeasureExecutionTime(Option<IStopwatch> options)
        {
            IStopwatch timer = new StopwatchTimer();
            options.IfSome(t => timer = t);
            _buildInvokeChain.Add(new StopWatchInvoker(timer));
            return this;
        }

        public IArrange New => new ArrangeWithContext(new DefaultContext(), new ConfigurableTestStepRunner(_buildInvokeChain.Root));
    }
}