using System;

namespace Fateblade.Haushaltsbuch.Logic.Foundation.Orchestration.Contract.Exceptions
{
    [Serializable]
    public class OrchestrationException : Exception
    {
        public OrchestrationException() { }
        public OrchestrationException(string message) : base(message) { }
        public OrchestrationException(string message, Exception inner) : base(message, inner) { }
        protected OrchestrationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
