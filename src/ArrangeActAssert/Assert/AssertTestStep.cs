using ArrangeActAssert.Context;
using FluentOptionals;
using System;

namespace ArrangeActAssert.Asrt
{
    public sealed class AssertTestStep : TestStepBase<AssertException>
    {
        private readonly Optional<string> _description;

        public AssertTestStep(IContext context, Action<IContext> action, Optional<string> description)
            :base(context, action)
        {
            _description = description;
        }

        public override string GetDescription()
        {
            var result = nameof(AssertTestStep);
            _description.IfSome(d => result = d);
            return result;
        }

        protected override AssertException GetException(Exception innerException)
            => new AssertException($"[Assert] failed with exception {innerException.GetType()}", innerException);
    }
}