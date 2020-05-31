using ArrangeActAssert.Arrange;
using ArrangeActAssert.Environment.Time;

namespace ArrangeActAssert.Configuration
{
    public interface IConfigure
    {
        IConfigure MeasureExecutionTime();
        IConfigure MeasureExecutionTime(IStopwatch options);

        IArrange New { get; }
    }
}