using ArrangeActAssert.Context;
using LanguageExt;
using System;

namespace ArrangeActAssert.Asrt
{
    public sealed class AssertTestStep : TestStepBase<AssertException>
    {
        private readonly Option<string> _description;

        public AssertTestStep(IContext context, Action<IContext> action, Option<string> description)
            :base(context, action)
        {
            _description = description;
        }

        public override string GetDescription()
        {
            var result = nameof(AssertTestStep);
            _description.Some(d => result = d);
            return result;
        }

        protected override AssertException GetException(Exception innerException)
        {
            return new AssertException("[Assert] fail.", innerException);
        }
    }
}