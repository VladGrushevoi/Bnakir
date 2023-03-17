using FluentValidation;
using MediatR;

namespace MapsterCard.Services.SystemService.UpdatePercentage;

public sealed record UpdatePercentageRequest(
    Guid Id,
    float? PercentageBetweenCountry,
    float? PercentageInCountry,
    float? PercentageBetweenCardSystem) : IRequest<UpdatePercentageResponse>;

public sealed record UpdatePercentageResponse
{
    public string PercentageBetweenCountry { get; set; }
    public string PercentageInCountry { get; set; }
    public string PercentageBetweenCardSystem { get; set; }
}

sealed class UpdatePercentageRequestValidation : AbstractValidator<UpdatePercentageRequest>
{
    public UpdatePercentageRequestValidation()
    {
        RuleFor(f => f.Id).NotEmpty().NotNull();
    }
}
