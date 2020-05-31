using ArrangeActAssert.Act;
using ArrangeActAssert.ShowCases.Tests;
using NUnit.Framework;
using System;

namespace ArrangeActAssert.Tests.ShowCases
{
    [TestFixture]
    public class SimpleTests
    {
        [Test]
        public void AddTwoNumbersUsingContext()
            => Pattern.Configure
                      .MeasureExecutionTime()
                      .New
                      .Arrange(ctx =>
                      {
                          ctx.SetSystemUnderTest(new Addition(1, 2));
                      }, "Prepare System under Test")
                      .Act(ctx =>
                      {
                          var sut = ctx.GetSystemUnderTest<Addition>();
                          var result = sut.Add();

                          ctx.SetValueToAssert(result);

                      }, "Add variables")
                      .Assert(ctx =>
                      {
                          int result = ctx.GetValueToAssert<int>();
                          Assert.AreEqual(3, result);
                      }, "Check if addition succeeded")
                      .Run();

        [Test]
        public void AddTwoNumbersUsingClosures()
        {
            int a = 0;
            int b = 0;
            int result = 0;
            Pattern.New
                   .Arrange(ctx =>
                   {
                       a = 1;
                       b = 2;
                   })
                   .Act(ctx => result = a + b)
                   .Assert(ctx => Assert.AreEqual(3, result))
                   .Run();
        }

        [Test]
        public void AddTwoNumbersUsingContext_ActThrowException_ExceptionConvertedToActException()
        {
            bool actExceptionThrown = false;
            try
            {

                Pattern.Configure
                         .MeasureExecutionTime()
                         .New
                         .Arrange(ctx =>
                         {
                             ctx.Add("a", 1);
                             ctx.Add("b", 2);
                         })
                         .Act(ctx =>
                         {
                             throw new Exception("Act failed");
                         })
                         .Assert(ctx =>
                         {
                         })
                         .Run();
            }
            catch (ActException exception)
            {
                Console.WriteLine(exception.ToString());
                actExceptionThrown = true;
            }

            Assert.IsTrue(actExceptionThrown);
        }
    }
}
