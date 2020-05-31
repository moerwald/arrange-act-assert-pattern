using ArrangeActAssert.Act;
using ArrangeActAssert.Context;
using System;

namespace ArrangeActAssert.Arrange
{
    public interface IArrange
    {
        IAct Arrange(Action<IContext> actionToInvoke);
        IAct Arrange(Action<IContext> actionToInvoke, string stepName);
    }
}