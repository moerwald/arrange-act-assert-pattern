using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Asrt
{
    public interface IAssert
    {
        ITestStepRunner Assert(Action<IContext> action);
        ITestStepRunner Assert(Action<IContext> action, string stepName);
    }
}
