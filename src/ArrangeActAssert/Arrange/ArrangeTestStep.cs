using ArrangeActAssert.Context;
using System;

namespace ArrangeActAssert.Arrange
{
    public sealed class ArrangeTestStep : TestStepBase<ArrangeException>
    {
        public ArrangeTestStep( IContext context, Action<IContext> actionToInvoke )
            :base(context, actionToInvoke)
        {
        }

        protected override ArrangeException GetException(Exception innerException)
            => new ArrangeException("[Arrange]: failed.", innerException);
    }
}