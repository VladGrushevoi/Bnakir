using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shklift.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    
    public DateOnly? CreatedAt { get; set; }
    
    public DateOnly? UpdatedAt { get; set; }
}