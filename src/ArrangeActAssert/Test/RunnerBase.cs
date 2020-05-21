using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using ArrangeActAssert.Asrt;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test
{
    public abstract class RunnerBase : ITestStepRunner
    {
        protected readonly List<ArrangeTestStep> _arrangeTestSteps = new List<ArrangeTestStep>();
        protected readonly List<ActTestStep> _actTestSteps = new List<ActTestStep>();
        protected readonly List<AssertTestStep> _assertTestSteps = new List<AssertTestStep>();

        public void AddAct(ActTestStep actTestStep) => _actTestSteps.Add(actTestStep);

        public void AddArrange(ArrangeTestStep arrangeTestStep) => _arrangeTestSteps.Add(arrangeTestStep);

        public void AddAssert(AssertTestStep assertTestStep) => _assertTestSteps.Add(assertTestStep);

        protected void InvokeArrangeSteps() => InvokeSteps(_arrangeTestSteps);
        protected void InvokeActSteps() => InvokeSteps(_actTestSteps);
        protected void InvokeAssertSteps() => InvokeSteps(_assertTestSteps);

        private void InvokeSteps<T>(IEnumerable<T> steps) where T : IInvokeableTestStep
        {
            foreach (var step in steps)
            {
                step.Invoke();
            }
        }

        public abstract void Run();
    }
}
