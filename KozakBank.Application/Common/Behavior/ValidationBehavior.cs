using FluentValidation;
using KozakBank.Application.Common.Exceptions;
using MediatR;

namespace KozakBank.Application.Common.Behavior;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        
        var validatorContext = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(x => x.Validate(validatorContext))
            .SelectMany(e => e.Errors)
            .Where(x => x != null)
            .Select(x => x.ErrorMessage)
            .Distinct()
            .ToArray();

        if (errors.Any())
        {
            throw new BadRequestException(errors);
        }

        return await next();
    }
}