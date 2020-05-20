using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert
{
    public abstract class TestStepBase<TException> 
        : IInvokeableTestStep
        where TException : Exception
    {
        protected  IContext Context { get; }

        protected Action<IContext> ActionToInvoke { get; }

        public TestStepBase( IContext context, Action<IContext> actionToInvoke )
        {
            Context = context;
            ActionToInvoke = actionToInvoke;
        }

        public void Invoke()
        {
            try
            {
                ActionToInvoke(Context);
            }
            catch (Exception exception)
            {
                throw GetException(exception);
            }
        }

        protected abstract TException GetException(Exception innerException);
        public abstract string GetDescription();
    }
}
