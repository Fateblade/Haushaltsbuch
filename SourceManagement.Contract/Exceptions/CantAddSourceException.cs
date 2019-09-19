using System;

namespace Fateblade.Haushaltsbuch.Logic.SourceManagement.Contract.Exceptions
{

    [Serializable]
    public class CantAddSourceException : SourceManagementException
    {
        public CantAddSourceException() { }
        public CantAddSourceException(string message) : base(message) { }
        public CantAddSourceException(string message, Exception inner) : base(message, inner) { }
        protected CantAddSourceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
