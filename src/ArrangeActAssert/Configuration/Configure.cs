using ArrangeActAssert.Arrange;
using ArrangeActAssert.Context;
using ArrangeActAssert.Environment.Time;
using ArrangeActAssert.Test;
using ArrangeActAssert.Test.Invoker;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Configuration
{
    public class Configure : IConfigure
    {
        private BuildInvokeList _buildInvokeChain = new BuildInvokeList();

        public Configure() { }

        public IConfigure MeasureExecutionTime(Optional<IStopwatch> options)
        {
            IStopwatch timer = new StopwatchTimer();
            options.IfSome(t => timer = t);
            _buildInvokeChain.Add(new StopWatchDecorator(timer));
            return this;
        }

        public IArrange New => new ArrangeWithContext(new DefaultContext(), new ConfigurableTestStepRunner(_buildInvokeChain.Root));
    }
}