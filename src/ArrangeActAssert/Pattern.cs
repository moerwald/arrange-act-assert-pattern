using ArrangeActAssert.Arrange;
using ArrangeActAssert.Test;

namespace ArrangeActAssert
{
    public static class Pattern
    {
        public static IArrange New => new ArrangeWithContext(new Context.DefaultContext(), new DefaultTestStepRunner());
    }
}
