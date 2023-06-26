using Kisa.Domain.Common;

namespace Kisa.Domain.Entities;

public sealed class KisaCard : BaseEntity
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string CountryName { get; set; }
    public DateOnly? CreatedAt { get; set; }
    public DateOnly? ExpireTo { get; set; }
    public string ShortExpireTo { get; set; }
}