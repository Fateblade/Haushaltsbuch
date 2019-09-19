using System;

namespace Fateblade.Haushaltsbuch.Logic.ItemManagement.Contract.Exceptions
{

    [Serializable]
    public class ItemManagementException : Exception
    {
        public ItemManagementException() { }
        public ItemManagementException(string message) : base(message) { }
        public ItemManagementException(string message, Exception inner) : base(message, inner) { }
        protected ItemManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
