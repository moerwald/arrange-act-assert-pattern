using FluentOptionals;

namespace ArrangeActAssert.Test.Invoker
{
    public abstract class InvokeBase : IInvoke
    {
        private Optional<IInvoke> _nextInvoker = Optional.None<IInvoke>();

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
            _nextInvoker = Optional.Some<IInvoke>(nextInvoker);
        }
    }
}
