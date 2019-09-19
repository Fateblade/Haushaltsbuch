using System;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions
{

    [Serializable]
    public class CantUpdateItemException : ItemManagementException
    {
        public CantUpdateItemException() { }
        public CantUpdateItemException(string message) : base(message) { }
        public CantUpdateItemException(string message, Exception inner) : base(message, inner) { }
        protected CantUpdateItemException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
