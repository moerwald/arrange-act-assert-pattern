using ArrangeActAssert.Arrange;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test
{
    public interface ITestStepRunner
    {
       void Invoke();
        void AddArrange(ArrangeTestStep arrangeTestStep);
    }
}
