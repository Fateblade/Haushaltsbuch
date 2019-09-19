using System;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions
{

    [Serializable]
    public class CantAddItemException : ItemManagementException
    {
        public CantAddItemException() { }
        public CantAddItemException(string message) : base(message) { }
        public CantAddItemException(string message, Exception inner) : base(message, inner) { }
        protected CantAddItemException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
