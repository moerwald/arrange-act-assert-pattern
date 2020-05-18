using ArrangeActAssert.Context;
using System;

namespace ArrangeActAssert.Act
{
    public class ActTestStep : TestStepBase<ActException>
    {
        public ActTestStep(IContext context, Action<IContext> action)
            :base (context, action)
        {
        }
        protected override ActException GetException(Exception innerException)
        {
            return new ActException("[Act] failed", innerException);

        }
    }
}
