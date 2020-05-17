﻿using ArrangeActAssert.Act;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Arrange
{
    internal sealed class ArrangeWithContext : IArrange
    {
        private IContext _context;
        private readonly ITestStepRunner _runner;

        public ArrangeWithContext(IContext context, ITestStepRunner runner)
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