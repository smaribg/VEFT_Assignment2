using System;
using System.Runtime.Serialization;

namespace CoursesApi.Models
{
    [Serializable]
    public class CourseFullException : Exception
    {
        public CourseFullException()
        {
        }

        public CourseFullException(string message) : base(message)
        {
        }

        public CourseFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CourseFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}