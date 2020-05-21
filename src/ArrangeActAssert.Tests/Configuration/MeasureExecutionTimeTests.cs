using ArrangeActAssert.Configuration.Time;
using NUnit.Framework;
using Moq;
using LanguageExt;
using ArrangeActAssert.Arrange;

namespace ArrangeActAssert.Tests.Configuration
{
    [TestFixture]
    public class MeasureExecutionTimeTests
    {
        private Mock<IStopwatch> _stopWatchMock;
        private IArrange _pattern;

        [SetUp]
        public void Setup()
        {
            _stopWatchMock = new Mock<IStopwatch>();
            _pattern = Pattern.Configure.MeasureExecutionTime(Option<IStopwatch>.Some(_stopWatchMock.Object)).New;
        }

        [Test]
        public void MeasureExecutionTime_StopWatchRestartMethodIsCalled()
        {
            RunDefaultPattern();

            _stopWatchMock.Verify(stopWatch => stopWatch.ReStart(), Times.Exactly(3));
        }

        [Test]
        public void MeasureExecutionTime_StopWatchStopMethodIsCalled()
        {
            RunDefaultPattern();

            _stopWatchMock.Verify(stopWatch => stopWatch.Stop(), Times.Exactly(3));
        }

        [Test]
        public void MeasureExecutionTime_StopWatchEllapsedMethodIsCalled()
        {
            RunDefaultPattern();

            _stopWatchMock.Verify(stopWatch => stopWatch.Elapsed(), Times.Exactly(3));
        }

        private void RunDefaultPattern() =>
            _pattern.Arrange(ctx => { }).Act(ctx => { }).Assert(ctx => { }).Run();

    }
}
