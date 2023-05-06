using System.ComponentModel.DataAnnotations;
using KozakBank.Domain.Common;

namespace KozakBank.Domain.Entities;

public class TransactionHistory : BaseEntity
{
    [Required]
    public Guid CardId { get; set; }
    [Range(0.01f, float.MaxValue)]
    public float AmountMoney { get; set; }
    [Range(0.01f, float.MaxValue)]
    public float Commission { get; set; }
}