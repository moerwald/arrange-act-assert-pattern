using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Arrange.Result
{
    internal class Success : ITestStepResult
    {
        void ITestStepResult.Success(Action yes, Action<string> no) => yes?.Invoke();
    }
}
