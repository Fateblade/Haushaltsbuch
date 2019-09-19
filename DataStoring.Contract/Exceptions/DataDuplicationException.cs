using System;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions
{
    [Serializable]
    public class DataDuplicationException : DataStoringException
    {
        public DataDuplicationException() { }
        public DataDuplicationException(string message) : base(message) { }
        public DataDuplicationException(string message, Exception inner) : base(message, inner) { }
        protected DataDuplicationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
