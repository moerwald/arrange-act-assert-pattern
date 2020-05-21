using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test
{
    public interface IInvokeableTestStep
    {
        void Invoke();

        string GetDescription();
    }
}
