using System;
using System.Runtime.Serialization;

[Serializable]
public class TravelerNullException : Exception
{
    public TravelerNullException()
    {
    }

    public TravelerNullException(string message) : base(message)
    {
    }

    public TravelerNullException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected TravelerNullException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}