using System;
using System.Collections.Generic;
using System.Text;

namespace ArrangeActAssert.Test.Invoker
{
    public sealed class BuildInvokeChain
    {
        public IInvoke Root { get; } = new RootInvoke();
        public IInvoke Head { get; private set; }

        public BuildInvokeChain() => Head = Root;

        public void Add(IInvoke next)
        {
            Head.SetNext(next);
            Head = next;
        }
    }
}
