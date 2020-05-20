
using ArrangeActAssert.Asrt;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.Arrange
{
    [TestFixture]
    public sealed class AssertTests
    {
        [Test]
        public void Assert_ExceptionIsThrown_ExceptionRethrownAsArrangeException()
        {
            Assert.Throws<AssertException>(
                () =>
                    Pattern.New
                            .Arrange(c => { })
                            .Act(x => {})
                            .Assert(x => throw new Exception("Assert failed"))
                            .Invoke()
                            );
        }

        [Test]
        public void Assert_NoError_ActionWasInvoked()
        {
            var assertStepCalled = false;
            Pattern.New
                    .Arrange(c => { })
                    .Act(x => {})
                    .Assert(x => assertStepCalled = true)
                    .Invoke();

            Assert.IsTrue(assertStepCalled);
        }

    }
}
