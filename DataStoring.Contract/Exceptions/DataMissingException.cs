using System;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions
{

    [Serializable]
    public class DataMissingException : DataStoringException
    {
        public DataMissingException() { }
        public DataMissingException(string message) : base(message) { }
        public DataMissingException(string message, Exception inner) : base(message, inner) { }
        protected DataMissingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
