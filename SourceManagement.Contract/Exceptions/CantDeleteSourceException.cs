using System;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions
{

    [Serializable]
    public class CantDeleteSourceException : SourceManagementException
    {
        public CantDeleteSourceException() { }
        public CantDeleteSourceException(string message) : base(message) { }
        public CantDeleteSourceException(string message, Exception inner) : base(message, inner) { }
        protected CantDeleteSourceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
