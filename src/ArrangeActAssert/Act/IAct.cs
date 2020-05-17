using ArrangeActAssert.Assert;
using ArrangeActAssert.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Act
{
    public interface IAct
    {
        IAssert Act(Action<IContext> action);
    }
}
