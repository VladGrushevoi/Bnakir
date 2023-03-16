using FluentValidation;
using MediatR;

namespace MapsterCard.Services.SystemService.AddSystemSettings;

public record AddSystemSettingsRequest(decimal Balance, 
    float PercentageOfOperationsBetweenCountry, 
    float PercentageOfOperationsInCountry) : IRequest<AddSystemSettingsResponse>;

public record AddSystemSettingsResponse
{
    public Guid id { get; set; }
    public string Balance { get; set; }
    public string PercentageBetweenCountry { get; set; }
    public string PercentageInCountry { get; set; }
}

public class AddSystemSettingsRequestValidation : AbstractValidator<AddSystemSettingsRequest>
{
    public AddSystemSettingsRequestValidation()
    {
        RuleFor(f => f.Balance)
            .NotEmpty()
            .NotNull()
            .GreaterThan(1);
        RuleFor(f => f.PercentageOfOperationsBetweenCountry)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0.01f);
        RuleFor(f => f.PercentageOfOperationsInCountry)
            .NotEmpty()
            .NotNull()
            .GreaterThan(0.01f);
    }
}
    
    