using System;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions
{

    [Serializable]
    public class EntryManagementException : Exception
    {
        public EntryManagementException() { }
        public EntryManagementException(string message) : base(message) { }
        public EntryManagementException(string message, Exception inner) : base(message, inner) { }
        protected EntryManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
