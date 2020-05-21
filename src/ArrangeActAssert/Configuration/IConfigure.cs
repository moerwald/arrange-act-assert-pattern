using ArrangeActAssert.Arrange;

namespace ArrangeActAssert.Configuration
{
    public interface IConfigure
    {
        IConfigure MeasureExecutionTime();
        IArrange New { get; }
    }
}