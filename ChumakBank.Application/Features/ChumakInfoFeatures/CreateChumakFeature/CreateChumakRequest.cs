using MediatR;

namespace ChumakBank.Application.Features.ChumakInfoFeatures.CreateChumakFeature;

public sealed record CreateChumakRequest(
        float Balance,
        float CommissionOfOperation
    ) : IRequest<CreateChumakResponse>;