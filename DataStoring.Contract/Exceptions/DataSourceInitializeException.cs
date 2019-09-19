using System;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.Contract.Exceptions
{

    [Serializable]
    public class DataSourceInitializeException : Exception
    {
        public DataSourceInitializeException() { }
        public DataSourceInitializeException(string message) : base(message) { }
        public DataSourceInitializeException(string message, Exception inner) : base(message, inner) { }
        protected DataSourceInitializeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
