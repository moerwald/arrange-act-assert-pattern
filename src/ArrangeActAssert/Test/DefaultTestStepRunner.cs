using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using System;
using System.Collections.Generic;

namespace ArrangeActAssert.Test
{
    public sealed class DefaultTestStepRunner : ITestStepRunner
    {
        List<ArrangeTestStep> _arrangeTestSteps = new List<ArrangeTestStep>();

        List<ActTestStep> _actTestSteps = new List<ActTestStep>();

        public void AddAct(ActTestStep actTestStep)
        {
            _actTestSteps.Add(actTestStep);
        }

        public void AddArrange(ArrangeTestStep arrangeTestStep)
        {
            _arrangeTestSteps.Add(arrangeTestStep);
        }

        public void Invoke()
        {
            InvokeSteps(_arrangeTestSteps);
            InvokeSteps(_actTestSteps);
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
