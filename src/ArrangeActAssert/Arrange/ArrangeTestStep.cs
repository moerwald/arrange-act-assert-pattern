using ArrangeActAssert.Context;
using ArrangeActAssert.Test;
using System;

namespace ArrangeActAssert.Arrange
{
    public class ArrangeTestStep : IInvokeableTestStep
    {
        private readonly IContext _context;
        private readonly Action<IContext> _actionToInvoke;

        public ArrangeTestStep( IContext context, Action<IContext> actionToInvoke )
        {
            _context = context;
            _actionToInvoke = actionToInvoke;
        }

        public void Invoke()
        {
            try
            {
                _actionToInvoke(_context);
            }
            catch (Exception exception)
            {
                throw new ArrangeException("Arrange step failed", exception);
            }
        }
    }
}