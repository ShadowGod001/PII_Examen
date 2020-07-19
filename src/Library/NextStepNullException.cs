using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    public class NextStepNullException : Exception
    {
        public NextStepNullException()
        {
        }

        public NextStepNullException(string message) : base(message)
        {
        }

        public NextStepNullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NextStepNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}