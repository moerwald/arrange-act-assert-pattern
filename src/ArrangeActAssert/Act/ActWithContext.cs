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

        public IAssert Act(Action<IContext> action) => Act(action, null);

        public IAssert Act(Action<IContext> action, string stepName)
        {
            _runner.AddAct(new ActTestStep(_context, action, Optional.From<string>(stepName)));
            return new AssertWithContext(_context, _runner);
        }
    }
}
