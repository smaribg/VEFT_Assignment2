using System;
using System.Runtime.Serialization;

namespace CoursesApi.Models
{
    [Serializable]
    public class AlreadyEnrolledException : Exception
    {
        public AlreadyEnrolledException()
        {
        }

        public AlreadyEnrolledException(string message) : base(message)
        {
        }

        public AlreadyEnrolledException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AlreadyEnrolledException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}