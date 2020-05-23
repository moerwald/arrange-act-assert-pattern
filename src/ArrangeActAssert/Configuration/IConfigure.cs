using ArrangeActAssert.Arrange;
using ArrangeActAssert.Environment.Time;
using FluentOptionals;

namespace ArrangeActAssert.Configuration
{
    public interface IConfigure
    {
        IConfigure MeasureExecutionTime(Optional<IStopwatch> options);
        IArrange New { get; }
    }
}