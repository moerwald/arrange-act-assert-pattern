using System;

namespace ArrangeActAssert.Act
{
    public class ActException : Exception
    {
        public ActException() { }
        public ActException(string message) : base(message) { }
        public ActException(string message, Exception inner) : base(message, inner) { }
    }
}
