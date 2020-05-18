using System;

namespace ArrangeActAssert.Act
{
    [Serializable]
    public class ActException : Exception
    {
        public ActException() { }
        public ActException(string message) : base(message) { }
        public ActException(string message, Exception inner) : base(message, inner) { }
        protected ActException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
