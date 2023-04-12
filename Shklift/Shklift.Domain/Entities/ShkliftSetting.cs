using System.ComponentModel.DataAnnotations;
using Shklift.Domain.Common;

namespace Shklift.Domain.Entities;

public sealed class ShkliftSetting : BaseEntity
{
    [Required(ErrorMessage = "Balance is required field")]
    [Range(0.1, float.PositiveInfinity, ErrorMessage = "Balance must be greater zero")]
    public float Balance { get; set; }
    
    [Required(ErrorMessage = "The transaction commission field is required")]
    [Range(0.1, 1f, ErrorMessage = "The value must be between 0.1 .. 1")]
    public float TransactionCommission { get; set; }
}