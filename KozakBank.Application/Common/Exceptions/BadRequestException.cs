namespace KozakBank.Application.Common.Exceptions;

public sealed class BadRequestException : Exception
{
    public string[] Errors { get; set; }

    public BadRequestException(string messages) : base(messages)
    {
        
    }

    public BadRequestException(string[] errors) : base(string.Join(" ", errors))
    {
        Errors = errors;
    }
}