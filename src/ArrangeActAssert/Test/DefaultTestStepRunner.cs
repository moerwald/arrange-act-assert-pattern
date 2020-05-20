using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using ArrangeActAssert.Asrt;
using System.Collections.Generic;

namespace ArrangeActAssert.Test
{
    public sealed class DefaultTestStepRunner : RunnerBase
    {
        public override void Invoke()
        {
            InvokeArrangeSteps();
            InvokeActSteps();
            InvokeAssertSteps();
        }
    }
}
