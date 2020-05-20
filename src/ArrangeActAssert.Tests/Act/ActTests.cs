using ArrangeActAssert.Act;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.Arrange
{
    [TestFixture]
    public sealed class ActTests
    {
        [Test]
        public void Act_ExceptionIsThrown_ExceptionRethrownAsArrangeException()
        {
            Assert.Throws<ActException>(
                () =>
                    Pattern.New
                            .Arrange(c => { })
                            .Act(x => throw new Exception("Act failed"))
                            .Assert(x => { })
                            .Invoke()
                            );
        }

        [Test]
        public void Act_NoError_ActionWasInvoked()
        {
            var actStepCalled = false;
            Pattern.New
                    .Arrange(c => { })
                    .Act(x => actStepCalled = true)
                    .Assert(x => { })
                    .Invoke();

            Assert.IsTrue(actStepCalled);
        }

    }
}
