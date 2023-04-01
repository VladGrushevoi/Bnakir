using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shklift.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Created at field is required")]
    [NotNull]
    public DateOnly? CreatedAt { get; set; }
    
    public DateOnly? UpdatedAt { get; set; }
}