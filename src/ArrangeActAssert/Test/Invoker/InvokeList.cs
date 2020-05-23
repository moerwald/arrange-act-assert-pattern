using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test.Invoker
{
    public sealed class InvokeList
    {
        public IInvoke Root { get; } = new RootInvoke();
        public IInvoke Head { get; private set; }

        public InvokeList() => Head = Root;

        public void Add(IInvoke next)
        {
            Head.SetNext(next);
            Head = next;
        }
    }
}
