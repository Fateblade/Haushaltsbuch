using System;

namespace Fateblade.Haushaltsbuch.Logic.EntryManagement.Contract.Exceptions
{

    [Serializable]
    public class CantUpdateEntryException : EntryManagementException
    {
        public CantUpdateEntryException() { }
        public CantUpdateEntryException(string message) : base(message) { }
        public CantUpdateEntryException(string message, Exception inner) : base(message, inner) { }
        protected CantUpdateEntryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
