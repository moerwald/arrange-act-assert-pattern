using ArrangeActAssert.Context;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Arrange
{
    public sealed class ArrangeTestStep : TestStepBase<ArrangeException>
    {
        private readonly Optional<string> _description;

        public ArrangeTestStep( IContext context, Action<IContext> actionToInvoke, Optional<string> description )
            :base(context, actionToInvoke)
        {
            _description = description;
        }
        public override string GetDescription()
        {
            var result = nameof(ArrangeTestStep);
            _description.IfSome(d => result = d);
            return result;
        }

        protected override ArrangeException GetException(Exception innerException)
            => new ArrangeException("[Arrange]: failed.", innerException);
    }
}