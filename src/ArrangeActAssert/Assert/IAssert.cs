using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Assert
{
    public interface IAssert
    {
        ITestRunner Assert(Action<IContext> context);
    }
}
