using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Arrange.Result
{
    internal class Error : ITestStepResult
    {
        private readonly Exception _exception;

        public Error(Exception exception)
        {
            _exception = exception;
        }

        public void Success(Action yes, Action<string> no)
            => no?.Invoke(_exception.ToString());
    }
}
