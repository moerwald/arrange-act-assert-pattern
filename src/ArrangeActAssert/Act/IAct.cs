using ArrangeActAssert.Asrt;
using ArrangeActAssert.Context;
using System;

namespace ArrangeActAssert.Act
{
    public interface IAct
    {
        IAssert Act(Action<IContext> action);
    }
}
