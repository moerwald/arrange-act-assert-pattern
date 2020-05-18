using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using ArrangeActAssert.Asrt;

namespace ArrangeActAssert.Test
{
    public interface ITestStepRunner
    {
        void Invoke();
        void AddArrange(ArrangeTestStep arrangeTestStep);
        void AddAct(ActTestStep actTestStep);
        void AddAssert(AssertTestStep assertTestStep);
    }
}
