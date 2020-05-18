using ArrangeActAssert.Context;
using System;

namespace ArrangeActAssert.Asrt
{
    public class AssertTestStep : TestStepBase<AssertException>
    {
        public AssertTestStep(IContext context, Action<IContext> action)
            :base(context, action)
        {
        }

        protected override AssertException GetException(Exception innerException)
        {
            return new AssertException("[Assert] fail.", innerException);
        }
    }
}