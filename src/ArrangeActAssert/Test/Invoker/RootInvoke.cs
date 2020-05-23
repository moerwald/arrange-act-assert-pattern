
using FluentOptionals;

namespace ArrangeActAssert.Test.Invoker
{
    public class RootInvoke : IInvokeDecorator
    {
        private Optional<IInvokeDecorator> _nextInvoke;

        public void Invoke(IInvokeableTestStep testStep) => _nextInvoke.IfSome(next => next.Invoke(testStep));

        public void SetNext(IInvokeDecorator nextInvoker) => _nextInvoke = Optional.Some<IInvokeDecorator>(nextInvoker);
    }
}
