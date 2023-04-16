namespace ChumakBank.Application.Common.Exception;

public class BadRequestException : System.Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string[] errors) : base(string.Join("\n",errors))
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}