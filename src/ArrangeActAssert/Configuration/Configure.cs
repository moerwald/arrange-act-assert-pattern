using ArrangeActAssert.Arrange;
using ArrangeActAssert.Context;
using ArrangeActAssert.Environment.Time;
using ArrangeActAssert.Test;
using ArrangeActAssert.Test.Invoker;
using FluentOptionals;

namespace ArrangeActAssert.Configuration
{
    public class Configure : IConfigure
    {
        private readonly InvokeList _buildInvokeChain = new InvokeList();

        private IConfigure MeasureExecutionTime(Optional<IStopwatch> options)
        {
            _buildInvokeChain.Add(
                new StopWatchDecorator( 
                        options.ValueOr( new StopwatchTimer()
                        )
                    )
                );
            return this;
        }

        public IConfigure MeasureExecutionTime() => MeasureExecutionTime(Optional.None<IStopwatch>());

        public IConfigure MeasureExecutionTime(IStopwatch stopwatch) => MeasureExecutionTime(Optional.From(stopwatch));

        public IArrange New => new ArrangeWithContext(new DefaultContext(), new ConfigurableTestStepRunner(_buildInvokeChain.Root));
    }
}