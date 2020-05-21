using ArrangeActAssert.Asrt;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Act
{
    internal sealed class ActWithContext : IAct
    {
        private readonly IContext _context;
        private readonly ITestStepRunner _runner;

        public ActWithContext(IContext context, ITestStepRunner runner)
        {
            _context = context;
            _runner = runner;
        }

        public IAssert Act(Action<IContext> action)
        {
            _runner.AddAct(new ActTestStep(_context, action, Optional.None<string>()));
            return new AssertWithContext(_context, _runner);
        }
    }
}
