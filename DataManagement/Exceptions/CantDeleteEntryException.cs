using System;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions
{

    [Serializable]
    public class CantDeleteEntryException : EntryManagementException
    {
        public CantDeleteEntryException() { }
        public CantDeleteEntryException(string message) : base(message) { }
        public CantDeleteEntryException(string message, Exception inner) : base(message, inner) { }
        protected CantDeleteEntryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
