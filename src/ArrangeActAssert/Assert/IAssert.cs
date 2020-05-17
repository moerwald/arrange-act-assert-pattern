using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Asrt
{
    public interface IAssert
    {
        ITestRunner Assert(Action<IContext> context);
    }
}
