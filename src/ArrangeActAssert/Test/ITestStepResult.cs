using System;

namespace ArrangeActAssert.Test
{
    public interface ITestStepResult
    {
        void Success(Action yes, Action<string> no);
    }
}