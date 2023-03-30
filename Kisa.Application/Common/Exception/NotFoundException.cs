namespace Kisa.Application.Common.Exception;

public sealed class NotFoundException : System.Exception
{
    public NotFoundException(string message) : base(message)
    {
    }
}