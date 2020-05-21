using ArrangeActAssert.Context;
using LanguageExt;
using System;

namespace ArrangeActAssert.Arrange
{
    public sealed class ArrangeTestStep : TestStepBase<ArrangeException>
    {
        private readonly Option<string> _description;

        public ArrangeTestStep( IContext context, Action<IContext> actionToInvoke, Option<string> description )
            :base(context, actionToInvoke)
        {
            _description = description;
        }
        public override string GetDescription()
        {
            var result = nameof(ArrangeTestStep);
            _description.Some(d => result = d);
            return result;
        }

        protected override ArrangeException GetException(Exception innerException)
            => new ArrangeException("[Arrange]: failed.", innerException);
    }
}