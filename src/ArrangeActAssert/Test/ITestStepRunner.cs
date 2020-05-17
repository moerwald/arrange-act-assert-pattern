using ArrangeActAssert.Arrange;

namespace ArrangeActAssert.Test
{
    public interface ITestStepRunner
    {
       void Invoke();
        void AddArrange(ArrangeTestStep arrangeTestStep);
    }
}
