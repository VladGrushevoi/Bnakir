namespace ChumakBank.Application.Common.Exception;

public sealed class InternalException : System.Exception
{
    public InternalException(string message) : base(message)
    {
        
    }
}