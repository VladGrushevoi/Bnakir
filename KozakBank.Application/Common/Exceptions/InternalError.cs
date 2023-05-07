namespace KozakBank.Application.Common.Exceptions;

public sealed class InternalError : Exception
{
    public InternalError(string message) : base(message)
    {
        
    }
}