using NUnit.Framework;

namespace ArrangeActAssert.Tests.TestStepRunner
{
    [TestFixture]
    public sealed class DefaultTestStepRunnerTest
    {

        [Test]
        public void TestRunner_Arrange_Invoked()
        {
            bool arrange = false;

            Pattern.New.Arrange(
                ctx =>
                {
                    arrange = true;
                }
                )
                .Act(
                ctx => 
                {
                }
                )
                .Assert(
                ctx => 
                {
                }
                )
                .Run();

            Assert.IsTrue(arrange);
        }

        [Test]
        public void TestRunner_Act_Invoked()
        {
            bool act = false;

            Pattern.New.Arrange(
                ctx =>
                {
                }
                )
                .Act(
                ctx => 
                {
                    act = true;
                }
                )
                .Assert(
                ctx => 
                {
                }
                )
                .Run();

            Assert.IsTrue(act);
        }

        [Test]
        public void TestRunner_Assert_Invoked()
        {
            bool assert = false;

            Pattern.New.Arrange(
                ctx =>
                {
                }
                )
                .Act(
                ctx => 
                {
                }
                )
                .Assert(
                ctx => 
                {
                    assert = true;
                }
                )
                .Run();

            Assert.IsTrue(assert);
        }
    }
}
