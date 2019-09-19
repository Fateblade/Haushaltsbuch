using System;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions
{

    [Serializable]
    public class CantDeleteItemException : ItemManagementException
    {
        public CantDeleteItemException() { }
        public CantDeleteItemException(string message) : base(message) { }
        public CantDeleteItemException(string message, Exception inner) : base(message, inner) { }
        protected CantDeleteItemException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
