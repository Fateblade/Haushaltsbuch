using System;

namespace CrossCutting.EventBrokerage.Contract.Exceptions
{

    [Serializable]
    public class EventBrokerageException : Exception
    {
        public EventBrokerageException() { }
        public EventBrokerageException(string message) : base(message) { }
        public EventBrokerageException(string message, Exception inner) : base(message, inner) { }
        protected EventBrokerageException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
