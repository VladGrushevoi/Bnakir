using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace KozakBank.Domain.Common;

public class BaseEntity
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public DateOnly CreatedOnly { get; set; }
    public DateOnly UpdatedAt { get; set; }
}