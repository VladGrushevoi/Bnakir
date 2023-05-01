using MediatR;

namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed record CreateChumakRequest(
        float Balance,
        float CommissionOfOperation,
        string BankIdentifier
    ) : IRequest<CreateChumakResponse>;