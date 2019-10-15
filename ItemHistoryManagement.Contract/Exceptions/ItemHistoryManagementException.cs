using System;

namespace Fateblade.Haushaltsbuch.Logic.Domain.ItemHistoryManagement.Contract.Exceptions
{
    [Serializable]
    public class ItemHistoryManagementException : Exception
    {
        public ItemHistoryManagementException() { }
        public ItemHistoryManagementException(string message) : base(message) { }
        public ItemHistoryManagementException(string message, Exception inner) : base(message, inner) { }
        protected ItemHistoryManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
