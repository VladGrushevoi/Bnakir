namespace ShkliftApplication.Common.Exception;

public sealed class BadRequestException : System.Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(string[] errors) : base(String.Join("\n", errors))
    {
        Errors = errors;
    }

    public string[] Errors { get; set; }
}