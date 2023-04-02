using System.ComponentModel.DataAnnotations;
using Shklift.Domain.Common;

namespace Shklift.Domain.Entities;

public sealed class Transaction : BaseEntity
{
    [Required(ErrorMessage = "The field from card number is required")]
    [StringLength(16, ErrorMessage = "Length of card number must be 16 numbers")]
    [RegularExpression("\\d{16}", ErrorMessage = "Card number must be contain 16 chars")]
    public string FromCardNumber { get; set; }
    
    [Required(ErrorMessage = "The field to card number is required")]
    [StringLength(16, ErrorMessage = "Length of card number must be 16 numbers")]
    [RegularExpression("\\d{16}", ErrorMessage = "Card number must be contain 16 chars")]
    public string ToCardNumber { get; set; }
    
    [Required(ErrorMessage = "Amount money is required")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "The field of Amount must be at less 1 number")]
    public string AmountMoney { get; set; }
}