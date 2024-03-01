namespace Domain.Exceptions;

public class StatusException : Exception
{
    public StatusException()
    {
    }

    public StatusException(string message)
        : base(message)
    {
    }
}