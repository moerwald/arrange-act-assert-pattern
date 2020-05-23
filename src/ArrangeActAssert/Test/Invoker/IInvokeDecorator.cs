namespace ArrangeActAssert.Test.Invoker
{
    public interface IInvokeDecorator
    {
        void Invoke(IInvokeableTestStep testStep);

        void SetNext(IInvokeDecorator nextInvoker);
    }
}
