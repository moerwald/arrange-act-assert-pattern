using ArrangeActAssert.Test.Invoker;

namespace ArrangeActAssert.Test
{
    public class ConfigurableTestStepRunner : RunnerBase
    {
        private readonly IInvoke _invoker;

        public ConfigurableTestStepRunner(IInvoke invoker)
        {
            _invoker = invoker;
        }

        public override void Run()
        {
            foreach (var step in _arrangeTestSteps)
                _invoker.Invoke(step);
            foreach (var step in _actTestSteps)
                _invoker.Invoke(step);
            foreach (var step in _assertTestSteps)
                _invoker.Invoke(step);
        }
    }
}
