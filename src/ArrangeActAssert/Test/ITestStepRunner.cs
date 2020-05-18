using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;

namespace ArrangeActAssert.Test
{
    public interface ITestStepRunner
    {
        void Invoke();
        void AddArrange(ArrangeTestStep arrangeTestStep);
        void AddAct(ActTestStep actTestStep);
    }
}
