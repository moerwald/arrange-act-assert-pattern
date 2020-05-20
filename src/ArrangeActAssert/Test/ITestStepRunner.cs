using ArrangeActAssert.Act;
using ArrangeActAssert.Arrange;
using ArrangeActAssert.Asrt;
using ArrangeActAssert.Test.Invoker;

namespace ArrangeActAssert.Test
{
    public interface ITestStepRunner 
    {
        void Run();
        void AddArrange(ArrangeTestStep arrangeTestStep);
        void AddAct(ActTestStep actTestStep);
        void AddAssert(AssertTestStep assertTestStep);
    }
}
