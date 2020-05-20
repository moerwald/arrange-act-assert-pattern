namespace ArrangeActAssert.Test
{
    public sealed class DefaultTestStepRunner : RunnerBase
    {
        public override void Run()
        {
            InvokeArrangeSteps();
            InvokeActSteps();
            InvokeAssertSteps();
        }
    }
}
