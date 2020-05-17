using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Asrt
{
    public class AssertWithContext : IAssert
    {
        private readonly IContext _context;
        private readonly ITestRunner _runner;

        public AssertWithContext(IContext context, ITestRunner runner)
        {
            _context = context;
            _runner = runner;
        }


        public ITestRunner Assert(Action<IContext> context)
        {
            return _runner;
        }
    }
}
