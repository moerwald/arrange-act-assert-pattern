using ArrangeActAssert.Arrange;
using FluentOptionals;

namespace ArrangeActAssert.Configuration
{
    public interface IConfigure
    {
        IConfigure MeasureExecutionTime(Optional<Time.IStopwatch> options);
        IArrange New { get; }
    }
}