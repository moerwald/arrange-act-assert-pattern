using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test.Invoker
{
    public sealed class InvokeList
    {
        public IInvokeDecorator Root { get; } = new RootInvoke();
        public IInvokeDecorator Head { get; private set; }

        public InvokeList() => Head = Root;

        public void Add(IInvokeDecorator next)
        {
            Head.SetNext(next);
            Head = next;
        }
    }
}
