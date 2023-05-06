using System.ComponentModel.DataAnnotations;
using KozakBank.Domain.Common;

namespace KozakBank.Domain.Entities;

public class KozakInfo : BaseEntity
{
    [Range(0.01f, float.MaxValue, ErrorMessage = "The balance should be greater than {1}")]
    public float Balance { get; set; }
    [Range(0.01f, float.MaxValue, ErrorMessage = "The commission should be greater than {1}")]
    public float CommissionValue { get; set; }
    [StringLength(4)]
    public string BankIdentifier { get; set; }
}