using System;

namespace ArrangeActAssert.Asrt
{
    public sealed class AssertException : Exception
    {
        public AssertException() { }
        public AssertException(string message) : base(message) { }
        public AssertException(string message, Exception inner) : base(message, inner) { }
    }
}