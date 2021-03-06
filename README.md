![.NET Core](https://github.com/moerwald/arrange-act-assert-pattern/workflows/.NET%20Core/badge.svg)
![publish to nuget](https://github.com/moerwald/arrange-act-assert-pattern/workflows/publish%20to%20nuget/badge.svg?branch=release%2F1.x.x)
[![BCH compliance](https://bettercodehub.com/edge/badge/moerwald/arrange-act-assert-pattern?branch=master)](https://bettercodehub.com/)

# arrange-act-assert-pattern

I'm fan of the Arrange-Act-Assert pattern. Test cases may become hard to read if this pattern is not used, or used via comments. In addition you never know if a test fails during the arrange, act, or assert phase. Based on that I decided to write a library making unit tests more readable.


Here is one simple example performing an addition of two variables:

```cs
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

```

The output of the testrun looks as:

```
Test Name:	AddTwoNumbersUsingContext
Test Outcome:	Passed
Result StandardOutput:	
Test step run: 2.5684 milliseconds. Test step description: Prepare System under Test
Test step run: 2.2287 milliseconds. Test step description: Add variables
Test step run: 0.4649 milliseconds. Test step description: Check if addition succeeded


```

Often there is also the problem that test cases break because of exceptions. Sometimes it is not obvious in which phase of the test the exception is thrown. The following example throws an exception in the ACT phase:

```cs
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
```

As can be seen the `Exception` is converted to an `ActException` which makes it easier to locate the code portion where the exception was thrown. The corresponding test output:

```
Test Name:	AddTwoNumbersUsingContext_ActThrowException_ExceptionConvertedToActException
Test Outcome:	Passed
Result StandardOutput:	
Test step run: 0.2237 milliseconds. Test step description: ArrangeTestStep
ArrangeActAssert.Act.ActException: [Act] failed with exception System.Exception
 ---> System.Exception: Act failed
   at ArrangeActAssert.Tests.ShowCases.SimpleTests.<>c.<AddTwoNumbersUsingContext_ActThrowException_ExceptionConvertedToActException>b__2_1(IContext ctx) in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert.ShowCases.Tests\SimpleTests.cs:line 77
   at ArrangeActAssert.TestStepBase`1.Invoke() in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\TestStepBase.cs:line 25
   --- End of inner exception stack trace ---
   at ArrangeActAssert.TestStepBase`1.Invoke() in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\TestStepBase.cs:line 29
   at ArrangeActAssert.Test.Invoker.ChainableInvoke.<>c__DisplayClass1_0.<Invoke>b__1() in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\Test\Invoker\ChainableInvoke.cs:line 14
   at FluentOptionals.Optional`1.Match(Action`1 some, Action none)
   at ArrangeActAssert.Test.Invoker.ChainableInvoke.Invoke(IInvokeableTestStep testStep) in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\Test\Invoker\ChainableInvoke.cs:line 12
   at ArrangeActAssert.Test.Invoker.RootInvoke.<>c__DisplayClass1_0.<Invoke>b__0(IInvokeDecorator next) in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\Test\Invoker\RootInvoke.cs:line 10
   at FluentOptionals.Optional`1.Match(Action`1 some, Action none)
   at FluentOptionals.Optional`1.IfSome(Action`1 handle)
   at ArrangeActAssert.Test.Invoker.RootInvoke.Invoke(IInvokeableTestStep testStep) in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\Test\Invoker\RootInvoke.cs:line 10
   at ArrangeActAssert.Test.ConfigurableTestStepRunner.Run() in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert\Test\ConfigurableTestStepRunner.cs:line 16
   at ArrangeActAssert.Tests.ShowCases.SimpleTests.AddTwoNumbersUsingContext_ActThrowException_ExceptionConvertedToActException() in C:\Users\andre\source\repos\arrange-act-assert-pattern\src\ArrangeActAssert.ShowCases.Tests\SimpleTests.cs:line 67


```

The output `ArrangeActAssert.Act.ActException: [Act] failed with exception System.Exception` shows the user that the ACT phase failed because of a `System.Exception`.
