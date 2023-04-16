using ChumakBank.Application.Common.Exception;
using FluentValidation;
using MediatR;

namespace ChumakBank.Application.Common.Behavior;

public sealed class ValidatorBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
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