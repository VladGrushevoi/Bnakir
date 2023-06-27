using System.Text.RegularExpressions;
using FluentValidation;
using MediatR;

namespace MapsterCard.Services.CardService.GetCardByProperties;

public sealed record GetCardByPropertiesRequest(
    string CardNumber,
    string CVV,
    string ExpireTo,
    string CreatedAt,
    string CountryName,
    string ShortExpireTo
) : IRequest<GetCardByPropertiesResponse>;

public sealed record GetCardByPropertiesResponse
{
    public string Id { get; set; }
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpireTo { get; set; }
    public string CreatedAt { get; set; }
    public string CountryName { get; set; }
    public string ShortExpireTo { get; set; }
}

public sealed partial class GetCardByPropertiesValidator : AbstractValidator<GetCardByPropertiesRequest>
{
    public GetCardByPropertiesValidator()
    {
        RuleFor(src => src.CardNumber).Length(16);
        RuleFor(src => src.CVV).Length(3);
        RuleFor(src => src.CountryName).MinimumLength(2);
        RuleFor(src => src.ShortExpireTo).Length(5).Matches("[0-9]{2}.[0-9]{2}");
        RuleFor(src => src.ExpireTo);//.Matches(MyRegex()); doesn`t work wtf
        RuleFor(src => src.CreatedAt); //.Matches(MyRegex()); doesn`t work wtf
    }

    [GeneratedRegex(@"{\d{4}-\d{2}-\d{2}}")]
    private static partial Regex MyRegex();
}
