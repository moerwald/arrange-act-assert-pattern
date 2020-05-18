using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using ArrangeActAssert.Asrt;
using System.Collections.Generic;

namespace ArrangeActAssert.Test
{
    public sealed class DefaultTestStepRunner : ITestStepRunner
    {
        readonly List<ArrangeTestStep> _arrangeTestSteps = new List<ArrangeTestStep>();
        readonly List<ActTestStep> _actTestSteps = new List<ActTestStep>();
        readonly List<AssertTestStep> _assertTestSteps = new List<AssertTestStep>();

        public void AddAct(ActTestStep actTestStep) => _actTestSteps.Add(actTestStep);

        public void AddArrange(ArrangeTestStep arrangeTestStep) => _arrangeTestSteps.Add(arrangeTestStep);

        public void AddAssert(AssertTestStep assertTestStep) => _assertTestSteps.Add(assertTestStep);

        public void Invoke()
        {
            InvokeSteps(_arrangeTestSteps);
            InvokeSteps(_actTestSteps);
            InvokeSteps(_assertTestSteps);
        }

        private void InvokeSteps<T>(IEnumerable<T> steps) where T : IInvokeableTestStep
        {
            foreach (var step in steps)
            {
                step.Invoke();
            }
        }
    }
}
