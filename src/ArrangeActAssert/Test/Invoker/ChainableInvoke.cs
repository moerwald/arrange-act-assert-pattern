using FluentOptionals;

namespace ArrangeActAssert.Test.Invoker
{
    public abstract class ChainableInvoke : IInvokeDecorator
    {
        private Optional<IInvokeDecorator> _nextInvoker = Optional.None<IInvokeDecorator>();

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

        public void SetNext(IInvokeDecorator nextInvoker)
        {
            _nextInvoker = Optional.Some<IInvokeDecorator>(nextInvoker);
        }
    }
}
