using System;

namespace BillManagement.Contract.Exceptions
{
    [Serializable]
    public class BillManagementException : Exception
    {
        public BillManagementException() { }
        public BillManagementException(string message) : base(message) { }
        public BillManagementException(string message, Exception inner) : base(message, inner) { }
        protected BillManagementException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
