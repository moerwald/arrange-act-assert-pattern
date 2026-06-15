using System;

namespace ArrangeActAssert.Arrange
{
    public sealed class ArrangeException : Exception
    {
        public ArrangeException() { }
        public ArrangeException(string message) : base(message) { }
        public ArrangeException(string message, Exception inner) : base(message, inner) { }
    }
}