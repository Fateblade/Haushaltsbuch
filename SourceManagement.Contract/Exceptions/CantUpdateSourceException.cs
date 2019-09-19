using System;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions
{

    [Serializable]
    public class CantUpdateSourceException : SourceManagementException
    {
        public CantUpdateSourceException() { }
        public CantUpdateSourceException(string message) : base(message) { }
        public CantUpdateSourceException(string message, Exception inner) : base(message, inner) { }
        protected CantUpdateSourceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
