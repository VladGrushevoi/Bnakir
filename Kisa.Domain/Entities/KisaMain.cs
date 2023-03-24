using Kisa.Domain.Common;

namespace Kisa.Domain.Entities;

public sealed class KisaMain : BaseEntity
{
    public double Balance { get; set; }
    public float CommissionInCountry { get; set; }
    public float CommissionBetweenCountry { get; set; }
    public float CommissionBetweenCardSystem { get; set; }
}