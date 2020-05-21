using ArrangeActAssert.Configuration.Time;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using LanguageExt;

namespace ArrangeActAssert.Tests.Configuration
{
    [TestFixture]
    public class MeasureExecutionTimeTests
    {
        [Test]
        public void MeasureExecutionTime_StopWatchRestartMethodIsCalled()
        {
            Mock<IStopwatch> stopWatchMock = new Mock<IStopwatch>();
            var pattern = Pattern.Configure.MeasureExecutionTime(Option<IStopwatch>.Some(stopWatchMock.Object)).New;

            pattern.Arrange(ctx => { }).Act(ctx => { }).Assert(ctx => { }).Run();

            stopWatchMock.Verify(stopWatch => stopWatch.ReStart(), Times.Exactly(3));
        }

        [Test]
        public void MeasureExecutionTime_StopWatchStopMethodIsCalled()
        {
            Mock<IStopwatch> stopWatchMock = new Mock<IStopwatch>();
            var pattern = Pattern.Configure.MeasureExecutionTime(Option<IStopwatch>.Some(stopWatchMock.Object)).New;

            pattern.Arrange(ctx => { }).Act(ctx => { }).Assert(ctx => { }).Run();

            stopWatchMock.Verify(stopWatch => stopWatch.Stop(), Times.Exactly(3));
        }

        [Test]
        public void MeasureExecutionTime_StopWatchEllapsedMethodIsCalled()
        {
            Mock<IStopwatch> stopWatchMock = new Mock<IStopwatch>();
            var pattern = Pattern.Configure.MeasureExecutionTime(Option<IStopwatch>.Some(stopWatchMock.Object)).New;

            pattern.Arrange(ctx => { }).Act(ctx => { }).Assert(ctx => { }).Run();

            stopWatchMock.Verify(stopWatch => stopWatch.Elapsed(), Times.Exactly(3));
        }

    }
}
