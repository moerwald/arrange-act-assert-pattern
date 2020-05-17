using ArrangeActAssert.Arrange;
using System.Collections.Generic;

namespace ArrangeActAssert.Test
{
    public class DefaultTestRunner : ITestRunner
    {
        List<ArrangeTestStep> _arrangeTestSteps = new List<ArrangeTestStep>();

        public void AddArrange(ArrangeTestStep arrangeTestStep)
        {
            _arrangeTestSteps.Add(arrangeTestStep);
        }

        public void Invoke()
        {
            InvokeArrangeSteps();
        }

        private void InvokeArrangeSteps()
        {
            foreach (var arrange in _arrangeTestSteps)
            {
                arrange.Invoke();
            }
        }
    }
}
