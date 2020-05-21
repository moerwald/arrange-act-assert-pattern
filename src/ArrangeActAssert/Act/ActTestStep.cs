using ArrangeActAssert.Context;
using LanguageExt;
using System;

namespace ArrangeActAssert.Act
{
    public sealed class ActTestStep : TestStepBase<ActException>
    {
        private readonly Option<string> _description;

        public ActTestStep(IContext context, Action<IContext> action, Option<string> description)
            :base (context, action)
        {
            _description = description;
        }

        public override string GetDescription()
        {
            var result = nameof(ActTestStep);
            _description.Some(d => result = d);
            return result;
        }
        protected override ActException GetException(Exception innerException)
        {
            return new ActException("[Act] failed", innerException);

        }
    }
}
