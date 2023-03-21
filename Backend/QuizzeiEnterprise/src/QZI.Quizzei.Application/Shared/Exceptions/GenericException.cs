using System.Runtime.Serialization;

namespace QZI.Quizzei.Application.Shared.Exceptions;

public class GenericException : Exception
{
    public GenericException(string message) : base(message)
    {
    }

    public GenericException(string message, Exception innerEx) : base(message, innerEx)
    {
    }

    public GenericException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}