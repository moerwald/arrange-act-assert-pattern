using ArrangeActAssert.Arrange;

namespace ArrangeActAssert.Configuration
{
    public interface IConfigure
    {
        IConfigure MeasureExecutionTime(LanguageExt.Option<Time.IStopwatch> options);
        IArrange New { get; }
    }
}