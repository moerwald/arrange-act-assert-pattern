using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test.Invoker
{
    public interface IInvoke
    {
        void Invoke(IInvokeableTestStep testStep);
        void SetNext(IInvoke nextInvoker);
    }
}
