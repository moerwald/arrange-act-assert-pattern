using ArrangeActAssert.Arrange;
using ArrangeActAssert.Configuration;
using ArrangeActAssert.Test;

namespace ArrangeActAssert
{
    public static class Pattern
    {
        public static IArrange New => new ArrangeWithContext(new Context.DefaultContext(), new DefaultTestStepRunner());

        public static IConfigure Configure => new Configure();
    }
}
