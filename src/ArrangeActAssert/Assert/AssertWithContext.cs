using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Asrt
{
    public sealed class AssertWithContext : IAssert
    {
        private readonly IContext _context;
        private readonly ITestStepRunner _runner;

        public AssertWithContext(IContext context, ITestStepRunner runner)
        {
            _context = context;
            _runner = runner;
        }


        public ITestStepRunner Assert(Action<IContext> context)
        {
            return _runner;
        }
    }
}
