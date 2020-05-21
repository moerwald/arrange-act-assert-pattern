using LanguageExt;
using System;

namespace ArrangeActAssert.Test.Invoker
{
    public abstract class InvokeBase : IInvoke
    {
        private Option<IInvoke> _nextInvoker = Option<IInvoke>.None;

        public void Invoke(IInvokeableTestStep testStep)
        {
            BeforeInvoke(testStep);
            _nextInvoker.Match(
                i => i.Invoke(testStep),
                () => testStep.Invoke()
                );
            AfterInvoke(testStep);
        }

        protected abstract void AfterInvoke(IInvokeableTestStep testStep);

        protected abstract void BeforeInvoke(IInvokeableTestStep testStep);

        public void SetNext(IInvoke nextInvoker)
        {
            _nextInvoker = Option<IInvoke>.Some(nextInvoker);
        }
    }
}
