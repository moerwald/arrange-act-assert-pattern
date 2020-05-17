﻿using ArrangeActAssert.Assert;
using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Act
{
    public class ActWithContext : IAct
    {
        private readonly IContext _context;
        private readonly ITestRunner _runner;

        public ActWithContext(IContext context, ITestRunner runner)
        {
            _context = context;
            _runner = runner;
        }

        public IAssert Act(Action<IContext> action)
        {
            throw new NotImplementedException();
        }

    }
}
