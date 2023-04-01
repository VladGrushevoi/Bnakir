using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Shklift.Domain.Common;

namespace Shklift.Domain.Entities;

public sealed class Transaction : BaseEntity
{
    [Required(ErrorMessage = "The field from card number is required")]
    [StringLength(16, ErrorMessage = "Length of card number must be 16 numbers")]
    [CreditCard]
    public string FromCardNumber { get; set; }
    
    [Required(ErrorMessage = "The field to card number is required")]
    [StringLength(16, ErrorMessage = "Length of card number must be 16 numbers")]
    [CreditCard]
    public string ToCardNumber { get; set; }
    
    [Required(ErrorMessage = "Amount money is required")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "The field of Amount must be at less 1 number")]
    public string AmountMoney { get; set; }
}