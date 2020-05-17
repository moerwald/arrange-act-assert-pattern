using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Tests.TestStepRunner
{
    [TestFixture]
    class DefaultTestStepRunnerTest
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
                .Invoke();

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
                .Invoke();

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
                .Invoke();

            Assert.IsTrue(assert);
        }
    }
}
