using ArrangeActAssert.Arrange;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.Arrange
{
    [TestFixture]
    public sealed class ArrangeTests
    {
        [Test]
        public void Arrange_ExceptionIsThrown_ExceptionRethrownAsArrangeException()
        {
            Assert.Throws<ArrangeException>(
                () =>
                    Pattern.New
                            .Arrange(c => throw new Exception("Arrange failed"))
                            .Act(x => { })
                            .Assert(x => { })
                            .Run()
                            );
        }

        [Test]
        public void Arrange_NoError_ActionWasInvoked()
        {
            var arrangeStepCalled = false;
            Pattern.New
                    .Arrange(c => arrangeStepCalled = true)
                    .Act(x => { })
                    .Assert(x => { })
                    .Run();

            Assert.IsTrue(arrangeStepCalled);
        }
    }
}
