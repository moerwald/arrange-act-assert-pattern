using ArrangeActAssert.Context;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Act
{
    public sealed class ActTestStep : TestStepBase<ActException>
    {
        private readonly Optional<string> _description;

        public ActTestStep(IContext context, Action<IContext> action, Optional<string> description)
            :base (context, action)
        {
            _description = description;
        }

        public override string GetDescription()
        {
            var result = nameof(ActTestStep);
            _description.IfSome(d => result = d);
            return result;
        }
        protected override ActException Convert(Exception innerException)
        {
            return new ActException($"[Act] failed with exception {innerException.GetType()}", innerException);

        }
    }
}
