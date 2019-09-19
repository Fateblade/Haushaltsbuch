using System;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions
{

    [Serializable]
    public class SourceManagementException : Exception
    {
        public SourceManagementException() { }
        public SourceManagementException(string message) : base(message) { }
        public SourceManagementException(string message, Exception inner) : base(message, inner) { }
        protected SourceManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
