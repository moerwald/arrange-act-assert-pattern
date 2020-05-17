using System;

namespace ArrangeActAssert.Arrange
{
    [Serializable]
    public sealed class ArrangeException : Exception
    {
        public ArrangeException() { }
        public ArrangeException(string message) : base(message) { }
        public ArrangeException(string message, Exception inner) : base(message, inner) { }
        protected ArrangeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}