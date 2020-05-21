using LanguageExt;

namespace ArrangeActAssert.Test.Invoker
{
    public class RootInvoke : IInvoke
    {
        private Option<IInvoke> _nextInvoke;

        public void Invoke(IInvokeableTestStep testStep) => _nextInvoke.IfSome(next => next.Invoke(testStep));

        public void SetNext(IInvoke nextInvoker) => _nextInvoke = Option<IInvoke>.Some(nextInvoker);
    }
}
