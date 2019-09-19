using System;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions
{

    [Serializable]
    public class CantAddEntryException : EntryManagementException
    {
        public CantAddEntryException() { }
        public CantAddEntryException(string message) : base(message) { }
        public CantAddEntryException(string message, Exception inner) : base(message, inner) { }
        protected CantAddEntryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
