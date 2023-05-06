using System.ComponentModel.DataAnnotations;
using KozakBank.Domain.Entities;

namespace KozakBank.Domain.Common;

public class BaseCard : BaseEntity
{
    [Required]
    public Guid IdFromCardSystem { get; set; }

    [Range(0f, float.MaxValue, ErrorMessage = "Balance cannot be negative value, please enter greater than {1}")]
    public float Balance { get; set; }
    [Required]
    public User User { get; set; }
}