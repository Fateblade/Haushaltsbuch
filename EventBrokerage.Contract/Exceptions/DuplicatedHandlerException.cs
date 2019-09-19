using System;

namespace CrossCutting.EventBrokerage.Contract.Exceptions
{

    [Serializable]
    public class DuplicatedHandlerException : EventBrokerageException
    {
        public DuplicatedHandlerException() { }
        public DuplicatedHandlerException(string message) : base(message) { }
        public DuplicatedHandlerException(string message, Exception inner) : base(message, inner) { }
        protected DuplicatedHandlerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
