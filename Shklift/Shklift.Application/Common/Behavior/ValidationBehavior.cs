using System.ComponentModel.DataAnnotations;
using MediatR;
using ShkliftApplication.Common.Exception;

namespace ShkliftApplication.Common.Behavior;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ICollection<ValidationResult> _validationResults;

    public ValidationBehavior()
    {
        _validationResults = new List<ValidationResult>();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext validationContext = new ValidationContext(request, null, null);

        bool valid = Validator.TryValidateObject(request, validationContext, _validationResults, true);
        if (!valid)
        {
            string?[] errors = _validationResults.Select(e => e.ErrorMessage).ToArray();
            throw new BadRequestException(errors);
        }
        return await next();
    }
}