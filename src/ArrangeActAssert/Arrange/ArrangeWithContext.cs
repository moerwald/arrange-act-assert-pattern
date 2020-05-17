using ArrangeActAssert.Act;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Arrange
{
    internal class ArrangeWithContext : IArrange
    {
        private IContext _context;
        private readonly ITestRunner _runner;

        public ArrangeWithContext(IContext context, ITestRunner runner)
        {
            _context = context;
            _runner = runner;
        }

        public IAct Arrange(Action<IContext> actionToInvoke)
        {
            _runner.AddArrange(new ArrangeTestStep(_context, actionToInvoke));
            return new ActWithContext(_context, _runner);
        }
    }
}