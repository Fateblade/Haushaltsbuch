using System;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions
{

    [Serializable]
    public class DataStoringException : Exception
    {
        public DataStoringException() { }
        public DataStoringException(string message) : base(message) { }
        public DataStoringException(string message, Exception inner) : base(message, inner) { }
        protected DataStoringException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
