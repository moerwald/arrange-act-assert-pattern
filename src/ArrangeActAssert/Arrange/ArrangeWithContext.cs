using ArrangeActAssert.Act;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Arrange
{
    internal sealed class ArrangeWithContext : IArrange
    {
        private IContext _context;
        private readonly ITestStepRunner _runner;

        internal ArrangeWithContext(IContext context, ITestStepRunner runner)
        {
            _context = context;
            _runner = runner;
        }

        public IAct Arrange(Action<IContext> actionToInvoke) => Arrange(actionToInvoke, null);

        public IAct Arrange(Action<IContext> actionToInvoke, string stepName)
        {
            _runner.AddArrange(new ArrangeTestStep(_context, actionToInvoke, Optional.From<string>(stepName)));
            return new ActWithContext(_context, _runner);
        }
    }
}