using System;
using System.Runtime.Serialization;

namespace CoursesApi.Models
{
    [Serializable]
    public class NotEnrolledException : Exception
    {
        public NotEnrolledException()
        {
        }

        public NotEnrolledException(string message) : base(message)
        {
        }

        public NotEnrolledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEnrolledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}